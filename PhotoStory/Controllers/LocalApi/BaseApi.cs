using PhotoStory.Data.Relational;
using PhotoStory.Data.Relational.Entities;
using PhotoStory.Models;
using PhotoStory.Util.SubModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoStory.Controllers.LocalApi {

	public abstract class BaseApi<TModelType, TEntityType> : IDisposable
		where TModelType : Model
		where TEntityType : Entity<TModelType> {

		private PhotoStoryContext _context;
		private DbSet<TEntityType> _workingDbSet;

		protected PhotoStoryContext Context {
			get {
				return _context;
			}
		}

		protected DbSet<TEntityType> WorkingDbSet {
			get {
				return _workingDbSet;
			}
		}

		protected abstract string WorkingDbSetName { get; }

		protected BaseApi() : this(new PhotoStoryContext()) { }

		protected BaseApi(PhotoStoryContext context) {
			_context = context;
			_workingDbSet = (DbSet<TEntityType>)typeof(PhotoStoryContext).GetProperty(WorkingDbSetName).GetValue(_context);
		}

		public virtual IEnumerable<TModelType> GetAll() {
			return _workingDbSet.ToList().ConvertAll(e => e.ToModel());
		}

		public virtual async Task<TModelType> Get(int id) {
			return (await _workingDbSet.FindAsync(id)).ToModel();
		}

		public virtual async Task Put(int id, TModelType model) {
			EnsureModelValidated(model);
			if (id != model.ID) {
				throw new Exception("Model IDs are inconsistent");
			}

			TEntityType entity = GetEntity(model);
			_context.Entry(entity).State = EntityState.Modified;
			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException ex) {
				if (!EntityExists(id)) {
					throw new Exception("Entity not found", ex);
				} else {
					throw ex;
				}
			}
		}

		public virtual async Task<TModelType> Post(TModelType model) {
			return await Post(model, null);
		}

		protected async Task<TModelType> Post(
			TModelType model,
			Func<Task<TEntityType>> customEntityFactory = null) {

			EnsureModelValidated(model);

			TEntityType entity = null;
			if (customEntityFactory == null) {
				entity = GetEntity(model);
				_workingDbSet.Add(entity);
				await _context.SaveChangesAsync();
			} else {
				entity = await customEntityFactory();
				EnsureModelValidated(model);
			}

			if (entity == null || entity.ID < 1) {
				throw new Exception("Unknown error: Entity could not be created");
			}

			return entity.ToModel();
		}

		public virtual async Task<TModelType> Delete(int id) {
			TEntityType entity = await _workingDbSet.FindAsync(id);
			if (entity == null) {
				throw new Exception("Entity not found");
			}

			_workingDbSet.Remove(entity);
			await _context.SaveChangesAsync();

			return entity.ToModel();
		}

		private TEntityType GetEntity(TModelType model) {
			TEntityType entity = Activator.CreateInstance<TEntityType>();
			ModelMapper.MapFromModel(model, entity);
			return entity;
		}

		private bool EntityExists(int id) {
			return _workingDbSet.Count(e => e.ID == id) > 0;
		}

		private void EnsureModelValidated(TModelType model) {
			var modelStateIsValid = true;
			if (!modelStateIsValid) {
				throw new Exception("Invalid model state");
			}
		}

		public void Dispose() {
			_context.Dispose();
		}
	}
}

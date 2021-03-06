﻿using PhotoStory.Data.Static;
using PhotoStory.Models.Public;
using PhotoStory.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PhotoStory.Controllers.LocalApi {

	public abstract class BaseApi<TModelType, TEntityType> : IDisposable
		where TModelType : Model<TEntityType>
		where TEntityType : Entity<TModelType> {

		private PhotoStoryContext _context;
		private DbSet<TEntityType> _workingDbSet;

		protected ChapterApi ChapterApi {
			get {
				return new ChapterApi(Context);
			}
		}

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

		protected Repository Repository {
			get {
				return RepositorySettings.Instance;
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
			TEntityType entity = await _workingDbSet.FindAsync(id);
			return entity.ToModel();
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
			return model.ToEntity();
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

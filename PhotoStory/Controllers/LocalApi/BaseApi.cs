using PhotoStory.Data.Relational;
using PhotoStory.Data.Relational.Entities;
using PhotoStory.Models;
using PhotoStory.Util;
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

		private PhotoStoryContext _db = new PhotoStoryContext();

		protected abstract DbSet<TEntityType> GetDbSetForEntity(PhotoStoryContext context);

		public virtual IEnumerable<TModelType> GetAll() {
			return GetDbSetForEntity(_db).ToList().ConvertAll(e => e.ToModel());
		}

		public virtual async Task<TEntityType> Get(int id) {
			return await GetDbSetForEntity(_db).FindAsync(id);
		}

		public virtual async Task Put(int id, TModelType model) {
			EnsureModelValidated(model);
			if (id != model.ID) {
				throw new Exception("Model IDs are inconsistent");
			}

			TEntityType entity = GetEntity(model);
			_db.Entry(entity).State = EntityState.Modified;
			try {
				await _db.SaveChangesAsync();
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
				GetDbSetForEntity(_db).Add(entity);
				await _db.SaveChangesAsync();
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
			TEntityType entity = await GetDbSetForEntity(_db).FindAsync(id);
			if (entity == null) {
				throw new Exception("Entity not found");
			}

			GetDbSetForEntity(_db).Remove(entity);
			await _db.SaveChangesAsync();

			return entity.ToModel();
		}

		private TEntityType GetEntity(TModelType model) {
			TEntityType entity = Activator.CreateInstance<TEntityType>();
			ModelMapper.MapFromModel<TModelType>(entity, model);
			return entity;
		}

		private bool EntityExists(int id) {
			return GetDbSetForEntity(_db).Count(e => e.ID == id) > 0;
		}

		private void EnsureModelValidated(TModelType model) {
			var modelStateIsValid = true;
			if (!modelStateIsValid) {
				throw new Exception("Invalid model state");
			}
		}

		public void Dispose() {
			_db.Dispose();
		}
	}
}

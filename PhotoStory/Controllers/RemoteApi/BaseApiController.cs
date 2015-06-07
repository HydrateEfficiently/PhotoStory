using PhotoStory.Controllers.LocalApi;
using PhotoStory.Data.Relational;
using PhotoStory.Data.Relational.Entities;
using PhotoStory.Models;
using PhotoStory.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace PhotoStory.Controllers.Api {

	public abstract class BaseApiController<TModelType, TEntityType> : ApiController 
		where TModelType : Model
		where TEntityType : Entity<TModelType> {

		private BaseApi<TModelType, TEntityType> _api;

		protected BaseApiController() {
			_api = GetApi();
		}

		protected abstract BaseApi<TModelType, TEntityType> GetApi();

		protected IEnumerable<TModelType> GetAll() {
			return _api.GetAll();
		}

		public async Task<IHttpActionResult> Get(int id) {
			TEntityType entity = await _api.Get(id);
			if (entity == null) {
				return NotFound();
			}
			return Ok(entity.ToModel());
		}

		protected async Task<IHttpActionResult> Put(int id, TModelType model) {
			await _api.Put(id, model);
			return StatusCode(HttpStatusCode.NoContent);
		}

		protected async Task<IHttpActionResult> Post(TModelType model) {
			TModelType postedModel = await _api.Post(model);
			return CreatedAtRoute("DefaultApi", new { id = model.ID }, model);
		}

		protected async Task<IHttpActionResult> Delete(int id) {
			TModelType deletedModel = await _api.Delete(id);
			return Ok(deletedModel);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				_api.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}

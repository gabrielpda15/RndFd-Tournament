using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RFT.Api.Interfaces;
using RFT.Api.Repository;
using RFT.Api.Repository.Models;
using RFT.Api.Repository.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RFT.Api.Controllers.Base
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController<TEntity> : Controller where TEntity : BaseEntity
    {
        protected IRepository<TEntity> Repository { get; }
        protected IUnitOfWork UnitOfWork { get; }

        public class PostRequest
        {
            public User User { get; set; }
            public TEntity Entity { get; set; }
        }

        public CrudController(IUnitOfWork unitOfWork) : base()
        {
            UnitOfWork = unitOfWork;
            Repository = unitOfWork.GetRepository<TEntity>();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Get(CancellationToken ct)
        {
            var result = await Repository.Get(ct: ct);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<TEntity> Post([FromBody]PostRequest request, CancellationToken ct)
        {
            var result = await Repository.Post(request.Entity, request.User, ct);
            await UnitOfWork.CommitAsync(ct);
            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            try
            {
                var result = await Repository.GetById(id, ct);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var result = await Repository.Delete(id, ct);
            await UnitOfWork.CommitAsync(ct);
            return result ? (IActionResult)Ok() : (IActionResult)NotFound();
        }

    }
}

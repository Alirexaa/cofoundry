﻿using Cofoundry.Core.Caching;
using Cofoundry.Core.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cofoundry.Web.Admin
{
    public class CacheApiController : BaseAdminApiController
    {
        private readonly IObjectCacheFactory _objectCacheFactory;
        private readonly IApiResponseHelper _apiResponseHelper;

        public CacheApiController(
            IApiResponseHelper apiResponseHelper,
            IObjectCacheFactory objectCacheFactory
            )
        {
            _objectCacheFactory = objectCacheFactory;
            _apiResponseHelper = apiResponseHelper;
        }

        /// <summary>
        /// Admin remote access method to clear the
        /// data cache in case we run into a caching issue in a live
        /// deployment
        /// </summary>
        public IActionResult Delete()
        {
            _objectCacheFactory.Clear();

            return _apiResponseHelper.SimpleCommandResponse(Enumerable.Empty<ValidationError>());
        }
    }
}
﻿using Cofoundry.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cofoundry.Domain.Internal
{
    /// <inheritdoc/>
    public class CustomEntityRouteMapper : ICustomEntityRouteMapper
    {
        public CustomEntityRoute Map(
            CustomEntity dbCustomEntity,
            ActiveLocale locale
            )
        {
            if (dbCustomEntity == null) throw new ArgumentNullException(nameof(dbCustomEntity));
            if (dbCustomEntity.CustomEntityVersions == null) throw new ArgumentNullException(nameof(dbCustomEntity.CustomEntityVersions));

            var route = new CustomEntityRoute()
            {
                CustomEntityDefinitionCode = dbCustomEntity.CustomEntityDefinitionCode,
                CustomEntityId = dbCustomEntity.CustomEntityId,
                UrlSlug = dbCustomEntity.UrlSlug,
                Locale = locale,
                PublishDate = dbCustomEntity.PublishDate,
                LastPublishDate = dbCustomEntity.LastPublishDate,
                PublishStatus = dbCustomEntity.PublishStatusCode == PublishStatusCode.Published ? PublishStatus.Published : PublishStatus.Unpublished,
                Ordering = dbCustomEntity.Ordering
            };

            bool hasLatestPublishVersion = false;
            route.Versions = new List<CustomEntityVersionRoute>();

            foreach (var dbVersion in dbCustomEntity
                .CustomEntityVersions
                .OrderByLatest())
            {
                var version = new CustomEntityVersionRoute()
                {
                    CreateDate = dbVersion.CreateDate,
                    Title = dbVersion.Title,
                    VersionId = dbVersion.CustomEntityVersionId,
                    WorkFlowStatus = (WorkFlowStatus)dbVersion.WorkFlowStatusId
                };

                if (!hasLatestPublishVersion && version.WorkFlowStatus == WorkFlowStatus.Published)
                {
                    version.IsLatestPublishedVersion = true;
                    hasLatestPublishVersion = true;
                }
                route.Versions.Add(version);
            }

            route.HasDraftVersion = route.Versions.Any(v => v.WorkFlowStatus == WorkFlowStatus.Draft);
            route.HasPublishedVersion = route.Versions.Any(v => v.WorkFlowStatus == WorkFlowStatus.Published);

            return route;
        }
    }
}
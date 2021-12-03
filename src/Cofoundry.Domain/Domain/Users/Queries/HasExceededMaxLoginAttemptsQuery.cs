﻿using Cofoundry.Domain.CQS;
using System.ComponentModel.DataAnnotations;

namespace Cofoundry.Domain
{
    public class HasExceededMaxLoginAttemptsQuery : IQuery<bool>
    {
        /// <summary>
        /// The <see cref="IUserAreaDefinition.UserAreaCode"/> of the user area 
        /// attempting to be logged in to.
        /// </summary>
        [Required]
        [StringLength(3)]
        public string UserAreaCode { get; set; }

        /// <summary>
        /// The username to check for. This is expected to be in a "uniquified" 
        /// format, as this should have been already processed whenever this
        /// needs to be called.
        /// </summary>
        [Required]
        public string Username { get; set; }
    }
}

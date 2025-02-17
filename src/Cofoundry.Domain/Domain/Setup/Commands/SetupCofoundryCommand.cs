﻿using Cofoundry.Domain.CQS;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cofoundry.Domain
{
    public class SetupCofoundryCommand : ICommand
    {
        [Required]
        [StringLength(50)]
        public string ApplicationName { get; set; }

        [StringLength(150)]
        public string DisplayName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public string Password { get; set; }

        /// <summary>
        /// True if a password change should be required when the master user 
        /// first logs. The default value is false but if setting up the site
        /// programmatically then you may want to set this to be true.
        /// </summary>
        public bool RequirePasswordChange { get; set; }
    }
}

/* 
 * EVE Swagger Interface
 *
 * An OpenAPI for EVE Online
 *
 * OpenAPI spec version: 0.7.6
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// new_mail object
    /// </summary>
    [DataContract]
    public partial class PostUiOpenwindowNewmailNewMail :  IEquatable<PostUiOpenwindowNewmailNewMail>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostUiOpenwindowNewmailNewMail" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PostUiOpenwindowNewmailNewMail() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PostUiOpenwindowNewmailNewMail" /> class.
        /// </summary>
        /// <param name="subject">subject string (required).</param>
        /// <param name="body">body string (required).</param>
        /// <param name="recipients">recipients array (required).</param>
        /// <param name="toMailingListId">Corporations, alliances and mailing lists are all types of mailing groups. You may only send to one mailing group, at a time, so you may fill out either this field or the to_corp_or_alliance_ids field.</param>
        /// <param name="toCorpOrAllianceId">to_corp_or_alliance_id integer.</param>
        public PostUiOpenwindowNewmailNewMail(string subject = default(string), string body = default(string), List<int?> recipients = default(List<int?>), int? toMailingListId = default(int?), int? toCorpOrAllianceId = default(int?))
        {
            // to ensure "subject" is required (not null)
            if (subject == null)
            {
                throw new InvalidDataException("subject is a required property for PostUiOpenwindowNewmailNewMail and cannot be null");
            }
            else
            {
                this.Subject = subject;
            }
            // to ensure "body" is required (not null)
            if (body == null)
            {
                throw new InvalidDataException("body is a required property for PostUiOpenwindowNewmailNewMail and cannot be null");
            }
            else
            {
                this.Body = body;
            }
            // to ensure "recipients" is required (not null)
            if (recipients == null)
            {
                throw new InvalidDataException("recipients is a required property for PostUiOpenwindowNewmailNewMail and cannot be null");
            }
            else
            {
                this.Recipients = recipients;
            }
            this.ToMailingListId = toMailingListId;
            this.ToCorpOrAllianceId = toCorpOrAllianceId;
        }
        
        /// <summary>
        /// subject string
        /// </summary>
        /// <value>subject string</value>
        [DataMember(Name="subject", EmitDefaultValue=false)]
        public string Subject { get; set; }

        /// <summary>
        /// body string
        /// </summary>
        /// <value>body string</value>
        [DataMember(Name="body", EmitDefaultValue=false)]
        public string Body { get; set; }

        /// <summary>
        /// recipients array
        /// </summary>
        /// <value>recipients array</value>
        [DataMember(Name="recipients", EmitDefaultValue=false)]
        public List<int?> Recipients { get; set; }

        /// <summary>
        /// Corporations, alliances and mailing lists are all types of mailing groups. You may only send to one mailing group, at a time, so you may fill out either this field or the to_corp_or_alliance_ids field
        /// </summary>
        /// <value>Corporations, alliances and mailing lists are all types of mailing groups. You may only send to one mailing group, at a time, so you may fill out either this field or the to_corp_or_alliance_ids field</value>
        [DataMember(Name="to_mailing_list_id", EmitDefaultValue=false)]
        public int? ToMailingListId { get; set; }

        /// <summary>
        /// to_corp_or_alliance_id integer
        /// </summary>
        /// <value>to_corp_or_alliance_id integer</value>
        [DataMember(Name="to_corp_or_alliance_id", EmitDefaultValue=false)]
        public int? ToCorpOrAllianceId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PostUiOpenwindowNewmailNewMail {\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  Recipients: ").Append(Recipients).Append("\n");
            sb.Append("  ToMailingListId: ").Append(ToMailingListId).Append("\n");
            sb.Append("  ToCorpOrAllianceId: ").Append(ToCorpOrAllianceId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PostUiOpenwindowNewmailNewMail);
        }

        /// <summary>
        /// Returns true if PostUiOpenwindowNewmailNewMail instances are equal
        /// </summary>
        /// <param name="input">Instance of PostUiOpenwindowNewmailNewMail to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PostUiOpenwindowNewmailNewMail input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Subject == input.Subject ||
                    (this.Subject != null &&
                    this.Subject.Equals(input.Subject))
                ) && 
                (
                    this.Body == input.Body ||
                    (this.Body != null &&
                    this.Body.Equals(input.Body))
                ) && 
                (
                    this.Recipients == input.Recipients ||
                    this.Recipients != null &&
                    this.Recipients.SequenceEqual(input.Recipients)
                ) && 
                (
                    this.ToMailingListId == input.ToMailingListId ||
                    (this.ToMailingListId != null &&
                    this.ToMailingListId.Equals(input.ToMailingListId))
                ) && 
                (
                    this.ToCorpOrAllianceId == input.ToCorpOrAllianceId ||
                    (this.ToCorpOrAllianceId != null &&
                    this.ToCorpOrAllianceId.Equals(input.ToCorpOrAllianceId))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Subject != null)
                    hashCode = hashCode * 59 + this.Subject.GetHashCode();
                if (this.Body != null)
                    hashCode = hashCode * 59 + this.Body.GetHashCode();
                if (this.Recipients != null)
                    hashCode = hashCode * 59 + this.Recipients.GetHashCode();
                if (this.ToMailingListId != null)
                    hashCode = hashCode * 59 + this.ToMailingListId.GetHashCode();
                if (this.ToCorpOrAllianceId != null)
                    hashCode = hashCode * 59 + this.ToCorpOrAllianceId.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // Subject (string) maxLength
            if(this.Subject != null && this.Subject.Length > 1000)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Subject, length must be less than 1000.", new [] { "Subject" });
            }

            // Body (string) maxLength
            if(this.Body != null && this.Body.Length > 10000)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Body, length must be less than 10000.", new [] { "Body" });
            }

            yield break;
        }
    }

}

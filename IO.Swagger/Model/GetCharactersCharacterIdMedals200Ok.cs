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
    /// 200 ok object
    /// </summary>
    [DataContract]
    public partial class GetCharactersCharacterIdMedals200Ok :  IEquatable<GetCharactersCharacterIdMedals200Ok>, IValidatableObject
    {
        /// <summary>
        /// status string
        /// </summary>
        /// <value>status string</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            
            /// <summary>
            /// Enum Public for value: public
            /// </summary>
            [EnumMember(Value = "public")]
            Public = 1,
            
            /// <summary>
            /// Enum Private for value: private
            /// </summary>
            [EnumMember(Value = "private")]
            Private = 2
        }

        /// <summary>
        /// status string
        /// </summary>
        /// <value>status string</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdMedals200Ok" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetCharactersCharacterIdMedals200Ok() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdMedals200Ok" /> class.
        /// </summary>
        /// <param name="medalId">medal_id integer (required).</param>
        /// <param name="title">title string (required).</param>
        /// <param name="description">description string (required).</param>
        /// <param name="corporationId">corporation_id integer (required).</param>
        /// <param name="issuerId">issuer_id integer (required).</param>
        /// <param name="date">date string (required).</param>
        /// <param name="reason">reason string (required).</param>
        /// <param name="status">status string (required).</param>
        /// <param name="graphics">graphics array (required).</param>
        public GetCharactersCharacterIdMedals200Ok(int? medalId = default(int?), string title = default(string), string description = default(string), int? corporationId = default(int?), int? issuerId = default(int?), DateTime? date = default(DateTime?), string reason = default(string), StatusEnum status = default(StatusEnum), List<GetCharactersCharacterIdMedalsGraphic> graphics = default(List<GetCharactersCharacterIdMedalsGraphic>))
        {
            // to ensure "medalId" is required (not null)
            if (medalId == null)
            {
                throw new InvalidDataException("medalId is a required property for GetCharactersCharacterIdMedals200Ok and cannot be null");
            }
            else
            {
                this.MedalId = medalId;
            }
            // to ensure "title" is required (not null)
            if (title == null)
            {
                throw new InvalidDataException("title is a required property for GetCharactersCharacterIdMedals200Ok and cannot be null");
            }
            else
            {
                this.Title = title;
            }
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new InvalidDataException("description is a required property for GetCharactersCharacterIdMedals200Ok and cannot be null");
            }
            else
            {
                this.Description = description;
            }
            // to ensure "corporationId" is required (not null)
            if (corporationId == null)
            {
                throw new InvalidDataException("corporationId is a required property for GetCharactersCharacterIdMedals200Ok and cannot be null");
            }
            else
            {
                this.CorporationId = corporationId;
            }
            // to ensure "issuerId" is required (not null)
            if (issuerId == null)
            {
                throw new InvalidDataException("issuerId is a required property for GetCharactersCharacterIdMedals200Ok and cannot be null");
            }
            else
            {
                this.IssuerId = issuerId;
            }
            // to ensure "date" is required (not null)
            if (date == null)
            {
                throw new InvalidDataException("date is a required property for GetCharactersCharacterIdMedals200Ok and cannot be null");
            }
            else
            {
                this.Date = date;
            }
            // to ensure "reason" is required (not null)
            if (reason == null)
            {
                throw new InvalidDataException("reason is a required property for GetCharactersCharacterIdMedals200Ok and cannot be null");
            }
            else
            {
                this.Reason = reason;
            }
            // to ensure "status" is required (not null)
            if (status == null)
            {
                throw new InvalidDataException("status is a required property for GetCharactersCharacterIdMedals200Ok and cannot be null");
            }
            else
            {
                this.Status = status;
            }
            // to ensure "graphics" is required (not null)
            if (graphics == null)
            {
                throw new InvalidDataException("graphics is a required property for GetCharactersCharacterIdMedals200Ok and cannot be null");
            }
            else
            {
                this.Graphics = graphics;
            }
        }
        
        /// <summary>
        /// medal_id integer
        /// </summary>
        /// <value>medal_id integer</value>
        [DataMember(Name="medal_id", EmitDefaultValue=false)]
        public int? MedalId { get; set; }

        /// <summary>
        /// title string
        /// </summary>
        /// <value>title string</value>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [DataMember(Name="corporation_id", EmitDefaultValue=false)]
        public int? CorporationId { get; set; }

        /// <summary>
        /// issuer_id integer
        /// </summary>
        /// <value>issuer_id integer</value>
        [DataMember(Name="issuer_id", EmitDefaultValue=false)]
        public int? IssuerId { get; set; }

        /// <summary>
        /// date string
        /// </summary>
        /// <value>date string</value>
        [DataMember(Name="date", EmitDefaultValue=false)]
        public DateTime? Date { get; set; }

        /// <summary>
        /// reason string
        /// </summary>
        /// <value>reason string</value>
        [DataMember(Name="reason", EmitDefaultValue=false)]
        public string Reason { get; set; }


        /// <summary>
        /// graphics array
        /// </summary>
        /// <value>graphics array</value>
        [DataMember(Name="graphics", EmitDefaultValue=false)]
        public List<GetCharactersCharacterIdMedalsGraphic> Graphics { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetCharactersCharacterIdMedals200Ok {\n");
            sb.Append("  MedalId: ").Append(MedalId).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  CorporationId: ").Append(CorporationId).Append("\n");
            sb.Append("  IssuerId: ").Append(IssuerId).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Graphics: ").Append(Graphics).Append("\n");
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
            return this.Equals(input as GetCharactersCharacterIdMedals200Ok);
        }

        /// <summary>
        /// Returns true if GetCharactersCharacterIdMedals200Ok instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCharactersCharacterIdMedals200Ok to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCharactersCharacterIdMedals200Ok input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.MedalId == input.MedalId ||
                    (this.MedalId != null &&
                    this.MedalId.Equals(input.MedalId))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.CorporationId == input.CorporationId ||
                    (this.CorporationId != null &&
                    this.CorporationId.Equals(input.CorporationId))
                ) && 
                (
                    this.IssuerId == input.IssuerId ||
                    (this.IssuerId != null &&
                    this.IssuerId.Equals(input.IssuerId))
                ) && 
                (
                    this.Date == input.Date ||
                    (this.Date != null &&
                    this.Date.Equals(input.Date))
                ) && 
                (
                    this.Reason == input.Reason ||
                    (this.Reason != null &&
                    this.Reason.Equals(input.Reason))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.Graphics == input.Graphics ||
                    this.Graphics != null &&
                    this.Graphics.SequenceEqual(input.Graphics)
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
                if (this.MedalId != null)
                    hashCode = hashCode * 59 + this.MedalId.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.CorporationId != null)
                    hashCode = hashCode * 59 + this.CorporationId.GetHashCode();
                if (this.IssuerId != null)
                    hashCode = hashCode * 59 + this.IssuerId.GetHashCode();
                if (this.Date != null)
                    hashCode = hashCode * 59 + this.Date.GetHashCode();
                if (this.Reason != null)
                    hashCode = hashCode * 59 + this.Reason.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Graphics != null)
                    hashCode = hashCode * 59 + this.Graphics.GetHashCode();
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
            yield break;
        }
    }

}
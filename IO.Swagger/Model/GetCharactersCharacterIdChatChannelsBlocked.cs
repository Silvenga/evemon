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
    /// blocked object
    /// </summary>
    [DataContract]
    public partial class GetCharactersCharacterIdChatChannelsBlocked :  IEquatable<GetCharactersCharacterIdChatChannelsBlocked>, IValidatableObject
    {
        /// <summary>
        /// accessor_type string
        /// </summary>
        /// <value>accessor_type string</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AccessorTypeEnum
        {
            
            /// <summary>
            /// Enum Character for value: character
            /// </summary>
            [EnumMember(Value = "character")]
            Character = 1,
            
            /// <summary>
            /// Enum Corporation for value: corporation
            /// </summary>
            [EnumMember(Value = "corporation")]
            Corporation = 2,
            
            /// <summary>
            /// Enum Alliance for value: alliance
            /// </summary>
            [EnumMember(Value = "alliance")]
            Alliance = 3
        }

        /// <summary>
        /// accessor_type string
        /// </summary>
        /// <value>accessor_type string</value>
        [DataMember(Name="accessor_type", EmitDefaultValue=false)]
        public AccessorTypeEnum AccessorType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdChatChannelsBlocked" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetCharactersCharacterIdChatChannelsBlocked() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharactersCharacterIdChatChannelsBlocked" /> class.
        /// </summary>
        /// <param name="accessorId">ID of a blocked channel member (required).</param>
        /// <param name="accessorType">accessor_type string (required).</param>
        /// <param name="reason">Reason this accessor is blocked.</param>
        /// <param name="endAt">Time at which this accessor will no longer be blocked.</param>
        public GetCharactersCharacterIdChatChannelsBlocked(int? accessorId = default(int?), AccessorTypeEnum accessorType = default(AccessorTypeEnum), string reason = default(string), DateTime? endAt = default(DateTime?))
        {
            // to ensure "accessorId" is required (not null)
            if (accessorId == null)
            {
                throw new InvalidDataException("accessorId is a required property for GetCharactersCharacterIdChatChannelsBlocked and cannot be null");
            }
            else
            {
                this.AccessorId = accessorId;
            }
            // to ensure "accessorType" is required (not null)
            if (accessorType == null)
            {
                throw new InvalidDataException("accessorType is a required property for GetCharactersCharacterIdChatChannelsBlocked and cannot be null");
            }
            else
            {
                this.AccessorType = accessorType;
            }
            this.Reason = reason;
            this.EndAt = endAt;
        }
        
        /// <summary>
        /// ID of a blocked channel member
        /// </summary>
        /// <value>ID of a blocked channel member</value>
        [DataMember(Name="accessor_id", EmitDefaultValue=false)]
        public int? AccessorId { get; set; }


        /// <summary>
        /// Reason this accessor is blocked
        /// </summary>
        /// <value>Reason this accessor is blocked</value>
        [DataMember(Name="reason", EmitDefaultValue=false)]
        public string Reason { get; set; }

        /// <summary>
        /// Time at which this accessor will no longer be blocked
        /// </summary>
        /// <value>Time at which this accessor will no longer be blocked</value>
        [DataMember(Name="end_at", EmitDefaultValue=false)]
        public DateTime? EndAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetCharactersCharacterIdChatChannelsBlocked {\n");
            sb.Append("  AccessorId: ").Append(AccessorId).Append("\n");
            sb.Append("  AccessorType: ").Append(AccessorType).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  EndAt: ").Append(EndAt).Append("\n");
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
            return this.Equals(input as GetCharactersCharacterIdChatChannelsBlocked);
        }

        /// <summary>
        /// Returns true if GetCharactersCharacterIdChatChannelsBlocked instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCharactersCharacterIdChatChannelsBlocked to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCharactersCharacterIdChatChannelsBlocked input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AccessorId == input.AccessorId ||
                    (this.AccessorId != null &&
                    this.AccessorId.Equals(input.AccessorId))
                ) && 
                (
                    this.AccessorType == input.AccessorType ||
                    (this.AccessorType != null &&
                    this.AccessorType.Equals(input.AccessorType))
                ) && 
                (
                    this.Reason == input.Reason ||
                    (this.Reason != null &&
                    this.Reason.Equals(input.Reason))
                ) && 
                (
                    this.EndAt == input.EndAt ||
                    (this.EndAt != null &&
                    this.EndAt.Equals(input.EndAt))
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
                if (this.AccessorId != null)
                    hashCode = hashCode * 59 + this.AccessorId.GetHashCode();
                if (this.AccessorType != null)
                    hashCode = hashCode * 59 + this.AccessorType.GetHashCode();
                if (this.Reason != null)
                    hashCode = hashCode * 59 + this.Reason.GetHashCode();
                if (this.EndAt != null)
                    hashCode = hashCode * 59 + this.EndAt.GetHashCode();
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
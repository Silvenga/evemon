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
    /// yesterday object
    /// </summary>
    [DataContract]
    public partial class GetFwLeaderboardsCharactersYesterday1 :  IEquatable<GetFwLeaderboardsCharactersYesterday1>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetFwLeaderboardsCharactersYesterday1" /> class.
        /// </summary>
        /// <param name="characterId">character_id integer.</param>
        /// <param name="amount">Amount of victory points.</param>
        public GetFwLeaderboardsCharactersYesterday1(int? characterId = default(int?), int? amount = default(int?))
        {
            this.CharacterId = characterId;
            this.Amount = amount;
        }
        
        /// <summary>
        /// character_id integer
        /// </summary>
        /// <value>character_id integer</value>
        [DataMember(Name="character_id", EmitDefaultValue=false)]
        public int? CharacterId { get; set; }

        /// <summary>
        /// Amount of victory points
        /// </summary>
        /// <value>Amount of victory points</value>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public int? Amount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetFwLeaderboardsCharactersYesterday1 {\n");
            sb.Append("  CharacterId: ").Append(CharacterId).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
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
            return this.Equals(input as GetFwLeaderboardsCharactersYesterday1);
        }

        /// <summary>
        /// Returns true if GetFwLeaderboardsCharactersYesterday1 instances are equal
        /// </summary>
        /// <param name="input">Instance of GetFwLeaderboardsCharactersYesterday1 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetFwLeaderboardsCharactersYesterday1 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CharacterId == input.CharacterId ||
                    (this.CharacterId != null &&
                    this.CharacterId.Equals(input.CharacterId))
                ) && 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
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
                if (this.CharacterId != null)
                    hashCode = hashCode * 59 + this.CharacterId.GetHashCode();
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
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

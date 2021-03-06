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
    /// Top 4 rankings of factions by number of kills from yesterday, last week and in total.
    /// </summary>
    [DataContract]
    public partial class GetFwLeaderboardsKills :  IEquatable<GetFwLeaderboardsKills>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetFwLeaderboardsKills" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetFwLeaderboardsKills() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetFwLeaderboardsKills" /> class.
        /// </summary>
        /// <param name="yesterday">Top 4 ranking of factions by kills in the past day (required).</param>
        /// <param name="lastWeek">Top 4 ranking of factions by kills in the past week (required).</param>
        /// <param name="activeTotal">Top 4 ranking of factions active in faction warfare by total kills. A faction is considered \&quot;active\&quot; if they have participated in faction warfare in the past 14 days. (required).</param>
        public GetFwLeaderboardsKills(List<GetFwLeaderboardsYesterday> yesterday = default(List<GetFwLeaderboardsYesterday>), List<GetFwLeaderboardsLastWeek> lastWeek = default(List<GetFwLeaderboardsLastWeek>), List<GetFwLeaderboardsActiveTotal> activeTotal = default(List<GetFwLeaderboardsActiveTotal>))
        {
            // to ensure "yesterday" is required (not null)
            if (yesterday == null)
            {
                throw new InvalidDataException("yesterday is a required property for GetFwLeaderboardsKills and cannot be null");
            }
            else
            {
                this.Yesterday = yesterday;
            }
            // to ensure "lastWeek" is required (not null)
            if (lastWeek == null)
            {
                throw new InvalidDataException("lastWeek is a required property for GetFwLeaderboardsKills and cannot be null");
            }
            else
            {
                this.LastWeek = lastWeek;
            }
            // to ensure "activeTotal" is required (not null)
            if (activeTotal == null)
            {
                throw new InvalidDataException("activeTotal is a required property for GetFwLeaderboardsKills and cannot be null");
            }
            else
            {
                this.ActiveTotal = activeTotal;
            }
        }
        
        /// <summary>
        /// Top 4 ranking of factions by kills in the past day
        /// </summary>
        /// <value>Top 4 ranking of factions by kills in the past day</value>
        [DataMember(Name="yesterday", EmitDefaultValue=false)]
        public List<GetFwLeaderboardsYesterday> Yesterday { get; set; }

        /// <summary>
        /// Top 4 ranking of factions by kills in the past week
        /// </summary>
        /// <value>Top 4 ranking of factions by kills in the past week</value>
        [DataMember(Name="last_week", EmitDefaultValue=false)]
        public List<GetFwLeaderboardsLastWeek> LastWeek { get; set; }

        /// <summary>
        /// Top 4 ranking of factions active in faction warfare by total kills. A faction is considered \&quot;active\&quot; if they have participated in faction warfare in the past 14 days.
        /// </summary>
        /// <value>Top 4 ranking of factions active in faction warfare by total kills. A faction is considered \&quot;active\&quot; if they have participated in faction warfare in the past 14 days.</value>
        [DataMember(Name="active_total", EmitDefaultValue=false)]
        public List<GetFwLeaderboardsActiveTotal> ActiveTotal { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetFwLeaderboardsKills {\n");
            sb.Append("  Yesterday: ").Append(Yesterday).Append("\n");
            sb.Append("  LastWeek: ").Append(LastWeek).Append("\n");
            sb.Append("  ActiveTotal: ").Append(ActiveTotal).Append("\n");
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
            return this.Equals(input as GetFwLeaderboardsKills);
        }

        /// <summary>
        /// Returns true if GetFwLeaderboardsKills instances are equal
        /// </summary>
        /// <param name="input">Instance of GetFwLeaderboardsKills to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetFwLeaderboardsKills input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Yesterday == input.Yesterday ||
                    this.Yesterday != null &&
                    this.Yesterday.SequenceEqual(input.Yesterday)
                ) && 
                (
                    this.LastWeek == input.LastWeek ||
                    this.LastWeek != null &&
                    this.LastWeek.SequenceEqual(input.LastWeek)
                ) && 
                (
                    this.ActiveTotal == input.ActiveTotal ||
                    this.ActiveTotal != null &&
                    this.ActiveTotal.SequenceEqual(input.ActiveTotal)
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
                if (this.Yesterday != null)
                    hashCode = hashCode * 59 + this.Yesterday.GetHashCode();
                if (this.LastWeek != null)
                    hashCode = hashCode * 59 + this.LastWeek.GetHashCode();
                if (this.ActiveTotal != null)
                    hashCode = hashCode * 59 + this.ActiveTotal.GetHashCode();
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

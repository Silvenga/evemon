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
    public partial class GetFwSystems200Ok :  IEquatable<GetFwSystems200Ok>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetFwSystems200Ok" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetFwSystems200Ok() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetFwSystems200Ok" /> class.
        /// </summary>
        /// <param name="solarSystemId">solar_system_id integer (required).</param>
        /// <param name="ownerFactionId">owner_faction_id integer (required).</param>
        /// <param name="occupierFactionId">occupier_faction_id integer (required).</param>
        /// <param name="victoryPoints">victory_points integer (required).</param>
        /// <param name="victoryPointsThreshold">victory_points_threshold integer (required).</param>
        /// <param name="contested">contested boolean (required).</param>
        public GetFwSystems200Ok(int? solarSystemId = default(int?), int? ownerFactionId = default(int?), int? occupierFactionId = default(int?), int? victoryPoints = default(int?), int? victoryPointsThreshold = default(int?), bool? contested = default(bool?))
        {
            // to ensure "solarSystemId" is required (not null)
            if (solarSystemId == null)
            {
                throw new InvalidDataException("solarSystemId is a required property for GetFwSystems200Ok and cannot be null");
            }
            else
            {
                this.SolarSystemId = solarSystemId;
            }
            // to ensure "ownerFactionId" is required (not null)
            if (ownerFactionId == null)
            {
                throw new InvalidDataException("ownerFactionId is a required property for GetFwSystems200Ok and cannot be null");
            }
            else
            {
                this.OwnerFactionId = ownerFactionId;
            }
            // to ensure "occupierFactionId" is required (not null)
            if (occupierFactionId == null)
            {
                throw new InvalidDataException("occupierFactionId is a required property for GetFwSystems200Ok and cannot be null");
            }
            else
            {
                this.OccupierFactionId = occupierFactionId;
            }
            // to ensure "victoryPoints" is required (not null)
            if (victoryPoints == null)
            {
                throw new InvalidDataException("victoryPoints is a required property for GetFwSystems200Ok and cannot be null");
            }
            else
            {
                this.VictoryPoints = victoryPoints;
            }
            // to ensure "victoryPointsThreshold" is required (not null)
            if (victoryPointsThreshold == null)
            {
                throw new InvalidDataException("victoryPointsThreshold is a required property for GetFwSystems200Ok and cannot be null");
            }
            else
            {
                this.VictoryPointsThreshold = victoryPointsThreshold;
            }
            // to ensure "contested" is required (not null)
            if (contested == null)
            {
                throw new InvalidDataException("contested is a required property for GetFwSystems200Ok and cannot be null");
            }
            else
            {
                this.Contested = contested;
            }
        }
        
        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [DataMember(Name="solar_system_id", EmitDefaultValue=false)]
        public int? SolarSystemId { get; set; }

        /// <summary>
        /// owner_faction_id integer
        /// </summary>
        /// <value>owner_faction_id integer</value>
        [DataMember(Name="owner_faction_id", EmitDefaultValue=false)]
        public int? OwnerFactionId { get; set; }

        /// <summary>
        /// occupier_faction_id integer
        /// </summary>
        /// <value>occupier_faction_id integer</value>
        [DataMember(Name="occupier_faction_id", EmitDefaultValue=false)]
        public int? OccupierFactionId { get; set; }

        /// <summary>
        /// victory_points integer
        /// </summary>
        /// <value>victory_points integer</value>
        [DataMember(Name="victory_points", EmitDefaultValue=false)]
        public int? VictoryPoints { get; set; }

        /// <summary>
        /// victory_points_threshold integer
        /// </summary>
        /// <value>victory_points_threshold integer</value>
        [DataMember(Name="victory_points_threshold", EmitDefaultValue=false)]
        public int? VictoryPointsThreshold { get; set; }

        /// <summary>
        /// contested boolean
        /// </summary>
        /// <value>contested boolean</value>
        [DataMember(Name="contested", EmitDefaultValue=false)]
        public bool? Contested { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetFwSystems200Ok {\n");
            sb.Append("  SolarSystemId: ").Append(SolarSystemId).Append("\n");
            sb.Append("  OwnerFactionId: ").Append(OwnerFactionId).Append("\n");
            sb.Append("  OccupierFactionId: ").Append(OccupierFactionId).Append("\n");
            sb.Append("  VictoryPoints: ").Append(VictoryPoints).Append("\n");
            sb.Append("  VictoryPointsThreshold: ").Append(VictoryPointsThreshold).Append("\n");
            sb.Append("  Contested: ").Append(Contested).Append("\n");
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
            return this.Equals(input as GetFwSystems200Ok);
        }

        /// <summary>
        /// Returns true if GetFwSystems200Ok instances are equal
        /// </summary>
        /// <param name="input">Instance of GetFwSystems200Ok to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetFwSystems200Ok input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SolarSystemId == input.SolarSystemId ||
                    (this.SolarSystemId != null &&
                    this.SolarSystemId.Equals(input.SolarSystemId))
                ) && 
                (
                    this.OwnerFactionId == input.OwnerFactionId ||
                    (this.OwnerFactionId != null &&
                    this.OwnerFactionId.Equals(input.OwnerFactionId))
                ) && 
                (
                    this.OccupierFactionId == input.OccupierFactionId ||
                    (this.OccupierFactionId != null &&
                    this.OccupierFactionId.Equals(input.OccupierFactionId))
                ) && 
                (
                    this.VictoryPoints == input.VictoryPoints ||
                    (this.VictoryPoints != null &&
                    this.VictoryPoints.Equals(input.VictoryPoints))
                ) && 
                (
                    this.VictoryPointsThreshold == input.VictoryPointsThreshold ||
                    (this.VictoryPointsThreshold != null &&
                    this.VictoryPointsThreshold.Equals(input.VictoryPointsThreshold))
                ) && 
                (
                    this.Contested == input.Contested ||
                    (this.Contested != null &&
                    this.Contested.Equals(input.Contested))
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
                if (this.SolarSystemId != null)
                    hashCode = hashCode * 59 + this.SolarSystemId.GetHashCode();
                if (this.OwnerFactionId != null)
                    hashCode = hashCode * 59 + this.OwnerFactionId.GetHashCode();
                if (this.OccupierFactionId != null)
                    hashCode = hashCode * 59 + this.OccupierFactionId.GetHashCode();
                if (this.VictoryPoints != null)
                    hashCode = hashCode * 59 + this.VictoryPoints.GetHashCode();
                if (this.VictoryPointsThreshold != null)
                    hashCode = hashCode * 59 + this.VictoryPointsThreshold.GetHashCode();
                if (this.Contested != null)
                    hashCode = hashCode * 59 + this.Contested.GetHashCode();
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

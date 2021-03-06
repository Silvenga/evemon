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
    public partial class GetCorporationsCorporationIdCustomsOffices200Ok :  IEquatable<GetCorporationsCorporationIdCustomsOffices200Ok>, IValidatableObject
    {
        /// <summary>
        /// Access is allowed only for entities with this level of standing or better
        /// </summary>
        /// <value>Access is allowed only for entities with this level of standing or better</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StandingLevelEnum
        {
            
            /// <summary>
            /// Enum Bad for value: bad
            /// </summary>
            [EnumMember(Value = "bad")]
            Bad = 1,
            
            /// <summary>
            /// Enum Excellent for value: excellent
            /// </summary>
            [EnumMember(Value = "excellent")]
            Excellent = 2,
            
            /// <summary>
            /// Enum Good for value: good
            /// </summary>
            [EnumMember(Value = "good")]
            Good = 3,
            
            /// <summary>
            /// Enum Neutral for value: neutral
            /// </summary>
            [EnumMember(Value = "neutral")]
            Neutral = 4,
            
            /// <summary>
            /// Enum Terrible for value: terrible
            /// </summary>
            [EnumMember(Value = "terrible")]
            Terrible = 5
        }

        /// <summary>
        /// Access is allowed only for entities with this level of standing or better
        /// </summary>
        /// <value>Access is allowed only for entities with this level of standing or better</value>
        [DataMember(Name="standing_level", EmitDefaultValue=false)]
        public StandingLevelEnum? StandingLevel { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCorporationsCorporationIdCustomsOffices200Ok" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetCorporationsCorporationIdCustomsOffices200Ok() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCorporationsCorporationIdCustomsOffices200Ok" /> class.
        /// </summary>
        /// <param name="officeId">unique ID of this customs office (required).</param>
        /// <param name="systemId">ID of the solar system this customs office is located in (required).</param>
        /// <param name="reinforceExitStart">Together with reinforce_exit_end, marks a 2-hour period where this customs office could exit reinforcement mode during the day after initial attack (required).</param>
        /// <param name="reinforceExitEnd">reinforce_exit_end integer (required).</param>
        /// <param name="corporationTaxRate">corporation_tax_rate number.</param>
        /// <param name="allowAllianceAccess">allow_alliance_access boolean (required).</param>
        /// <param name="allianceTaxRate">Only present if alliance access is allowed.</param>
        /// <param name="allowAccessWithStandings">standing_level and any standing related tax rate only present when this is true (required).</param>
        /// <param name="standingLevel">Access is allowed only for entities with this level of standing or better.</param>
        /// <param name="excellentStandingTaxRate">Tax rate for entities with excellent level of standing, only present if this level is allowed, same for all other standing related tax rates.</param>
        /// <param name="goodStandingTaxRate">good_standing_tax_rate number.</param>
        /// <param name="neutralStandingTaxRate">neutral_standing_tax_rate number.</param>
        /// <param name="badStandingTaxRate">bad_standing_tax_rate number.</param>
        /// <param name="terribleStandingTaxRate">terrible_standing_tax_rate number.</param>
        public GetCorporationsCorporationIdCustomsOffices200Ok(long? officeId = default(long?), int? systemId = default(int?), int? reinforceExitStart = default(int?), int? reinforceExitEnd = default(int?), float? corporationTaxRate = default(float?), bool? allowAllianceAccess = default(bool?), float? allianceTaxRate = default(float?), bool? allowAccessWithStandings = default(bool?), StandingLevelEnum? standingLevel = default(StandingLevelEnum?), float? excellentStandingTaxRate = default(float?), float? goodStandingTaxRate = default(float?), float? neutralStandingTaxRate = default(float?), float? badStandingTaxRate = default(float?), float? terribleStandingTaxRate = default(float?))
        {
            // to ensure "officeId" is required (not null)
            if (officeId == null)
            {
                throw new InvalidDataException("officeId is a required property for GetCorporationsCorporationIdCustomsOffices200Ok and cannot be null");
            }
            else
            {
                this.OfficeId = officeId;
            }
            // to ensure "systemId" is required (not null)
            if (systemId == null)
            {
                throw new InvalidDataException("systemId is a required property for GetCorporationsCorporationIdCustomsOffices200Ok and cannot be null");
            }
            else
            {
                this.SystemId = systemId;
            }
            // to ensure "reinforceExitStart" is required (not null)
            if (reinforceExitStart == null)
            {
                throw new InvalidDataException("reinforceExitStart is a required property for GetCorporationsCorporationIdCustomsOffices200Ok and cannot be null");
            }
            else
            {
                this.ReinforceExitStart = reinforceExitStart;
            }
            // to ensure "reinforceExitEnd" is required (not null)
            if (reinforceExitEnd == null)
            {
                throw new InvalidDataException("reinforceExitEnd is a required property for GetCorporationsCorporationIdCustomsOffices200Ok and cannot be null");
            }
            else
            {
                this.ReinforceExitEnd = reinforceExitEnd;
            }
            // to ensure "allowAllianceAccess" is required (not null)
            if (allowAllianceAccess == null)
            {
                throw new InvalidDataException("allowAllianceAccess is a required property for GetCorporationsCorporationIdCustomsOffices200Ok and cannot be null");
            }
            else
            {
                this.AllowAllianceAccess = allowAllianceAccess;
            }
            // to ensure "allowAccessWithStandings" is required (not null)
            if (allowAccessWithStandings == null)
            {
                throw new InvalidDataException("allowAccessWithStandings is a required property for GetCorporationsCorporationIdCustomsOffices200Ok and cannot be null");
            }
            else
            {
                this.AllowAccessWithStandings = allowAccessWithStandings;
            }
            this.CorporationTaxRate = corporationTaxRate;
            this.AllianceTaxRate = allianceTaxRate;
            this.StandingLevel = standingLevel;
            this.ExcellentStandingTaxRate = excellentStandingTaxRate;
            this.GoodStandingTaxRate = goodStandingTaxRate;
            this.NeutralStandingTaxRate = neutralStandingTaxRate;
            this.BadStandingTaxRate = badStandingTaxRate;
            this.TerribleStandingTaxRate = terribleStandingTaxRate;
        }
        
        /// <summary>
        /// unique ID of this customs office
        /// </summary>
        /// <value>unique ID of this customs office</value>
        [DataMember(Name="office_id", EmitDefaultValue=false)]
        public long? OfficeId { get; set; }

        /// <summary>
        /// ID of the solar system this customs office is located in
        /// </summary>
        /// <value>ID of the solar system this customs office is located in</value>
        [DataMember(Name="system_id", EmitDefaultValue=false)]
        public int? SystemId { get; set; }

        /// <summary>
        /// Together with reinforce_exit_end, marks a 2-hour period where this customs office could exit reinforcement mode during the day after initial attack
        /// </summary>
        /// <value>Together with reinforce_exit_end, marks a 2-hour period where this customs office could exit reinforcement mode during the day after initial attack</value>
        [DataMember(Name="reinforce_exit_start", EmitDefaultValue=false)]
        public int? ReinforceExitStart { get; set; }

        /// <summary>
        /// reinforce_exit_end integer
        /// </summary>
        /// <value>reinforce_exit_end integer</value>
        [DataMember(Name="reinforce_exit_end", EmitDefaultValue=false)]
        public int? ReinforceExitEnd { get; set; }

        /// <summary>
        /// corporation_tax_rate number
        /// </summary>
        /// <value>corporation_tax_rate number</value>
        [DataMember(Name="corporation_tax_rate", EmitDefaultValue=false)]
        public float? CorporationTaxRate { get; set; }

        /// <summary>
        /// allow_alliance_access boolean
        /// </summary>
        /// <value>allow_alliance_access boolean</value>
        [DataMember(Name="allow_alliance_access", EmitDefaultValue=false)]
        public bool? AllowAllianceAccess { get; set; }

        /// <summary>
        /// Only present if alliance access is allowed
        /// </summary>
        /// <value>Only present if alliance access is allowed</value>
        [DataMember(Name="alliance_tax_rate", EmitDefaultValue=false)]
        public float? AllianceTaxRate { get; set; }

        /// <summary>
        /// standing_level and any standing related tax rate only present when this is true
        /// </summary>
        /// <value>standing_level and any standing related tax rate only present when this is true</value>
        [DataMember(Name="allow_access_with_standings", EmitDefaultValue=false)]
        public bool? AllowAccessWithStandings { get; set; }


        /// <summary>
        /// Tax rate for entities with excellent level of standing, only present if this level is allowed, same for all other standing related tax rates
        /// </summary>
        /// <value>Tax rate for entities with excellent level of standing, only present if this level is allowed, same for all other standing related tax rates</value>
        [DataMember(Name="excellent_standing_tax_rate", EmitDefaultValue=false)]
        public float? ExcellentStandingTaxRate { get; set; }

        /// <summary>
        /// good_standing_tax_rate number
        /// </summary>
        /// <value>good_standing_tax_rate number</value>
        [DataMember(Name="good_standing_tax_rate", EmitDefaultValue=false)]
        public float? GoodStandingTaxRate { get; set; }

        /// <summary>
        /// neutral_standing_tax_rate number
        /// </summary>
        /// <value>neutral_standing_tax_rate number</value>
        [DataMember(Name="neutral_standing_tax_rate", EmitDefaultValue=false)]
        public float? NeutralStandingTaxRate { get; set; }

        /// <summary>
        /// bad_standing_tax_rate number
        /// </summary>
        /// <value>bad_standing_tax_rate number</value>
        [DataMember(Name="bad_standing_tax_rate", EmitDefaultValue=false)]
        public float? BadStandingTaxRate { get; set; }

        /// <summary>
        /// terrible_standing_tax_rate number
        /// </summary>
        /// <value>terrible_standing_tax_rate number</value>
        [DataMember(Name="terrible_standing_tax_rate", EmitDefaultValue=false)]
        public float? TerribleStandingTaxRate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetCorporationsCorporationIdCustomsOffices200Ok {\n");
            sb.Append("  OfficeId: ").Append(OfficeId).Append("\n");
            sb.Append("  SystemId: ").Append(SystemId).Append("\n");
            sb.Append("  ReinforceExitStart: ").Append(ReinforceExitStart).Append("\n");
            sb.Append("  ReinforceExitEnd: ").Append(ReinforceExitEnd).Append("\n");
            sb.Append("  CorporationTaxRate: ").Append(CorporationTaxRate).Append("\n");
            sb.Append("  AllowAllianceAccess: ").Append(AllowAllianceAccess).Append("\n");
            sb.Append("  AllianceTaxRate: ").Append(AllianceTaxRate).Append("\n");
            sb.Append("  AllowAccessWithStandings: ").Append(AllowAccessWithStandings).Append("\n");
            sb.Append("  StandingLevel: ").Append(StandingLevel).Append("\n");
            sb.Append("  ExcellentStandingTaxRate: ").Append(ExcellentStandingTaxRate).Append("\n");
            sb.Append("  GoodStandingTaxRate: ").Append(GoodStandingTaxRate).Append("\n");
            sb.Append("  NeutralStandingTaxRate: ").Append(NeutralStandingTaxRate).Append("\n");
            sb.Append("  BadStandingTaxRate: ").Append(BadStandingTaxRate).Append("\n");
            sb.Append("  TerribleStandingTaxRate: ").Append(TerribleStandingTaxRate).Append("\n");
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
            return this.Equals(input as GetCorporationsCorporationIdCustomsOffices200Ok);
        }

        /// <summary>
        /// Returns true if GetCorporationsCorporationIdCustomsOffices200Ok instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCorporationsCorporationIdCustomsOffices200Ok to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetCorporationsCorporationIdCustomsOffices200Ok input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.OfficeId == input.OfficeId ||
                    (this.OfficeId != null &&
                    this.OfficeId.Equals(input.OfficeId))
                ) && 
                (
                    this.SystemId == input.SystemId ||
                    (this.SystemId != null &&
                    this.SystemId.Equals(input.SystemId))
                ) && 
                (
                    this.ReinforceExitStart == input.ReinforceExitStart ||
                    (this.ReinforceExitStart != null &&
                    this.ReinforceExitStart.Equals(input.ReinforceExitStart))
                ) && 
                (
                    this.ReinforceExitEnd == input.ReinforceExitEnd ||
                    (this.ReinforceExitEnd != null &&
                    this.ReinforceExitEnd.Equals(input.ReinforceExitEnd))
                ) && 
                (
                    this.CorporationTaxRate == input.CorporationTaxRate ||
                    (this.CorporationTaxRate != null &&
                    this.CorporationTaxRate.Equals(input.CorporationTaxRate))
                ) && 
                (
                    this.AllowAllianceAccess == input.AllowAllianceAccess ||
                    (this.AllowAllianceAccess != null &&
                    this.AllowAllianceAccess.Equals(input.AllowAllianceAccess))
                ) && 
                (
                    this.AllianceTaxRate == input.AllianceTaxRate ||
                    (this.AllianceTaxRate != null &&
                    this.AllianceTaxRate.Equals(input.AllianceTaxRate))
                ) && 
                (
                    this.AllowAccessWithStandings == input.AllowAccessWithStandings ||
                    (this.AllowAccessWithStandings != null &&
                    this.AllowAccessWithStandings.Equals(input.AllowAccessWithStandings))
                ) && 
                (
                    this.StandingLevel == input.StandingLevel ||
                    (this.StandingLevel != null &&
                    this.StandingLevel.Equals(input.StandingLevel))
                ) && 
                (
                    this.ExcellentStandingTaxRate == input.ExcellentStandingTaxRate ||
                    (this.ExcellentStandingTaxRate != null &&
                    this.ExcellentStandingTaxRate.Equals(input.ExcellentStandingTaxRate))
                ) && 
                (
                    this.GoodStandingTaxRate == input.GoodStandingTaxRate ||
                    (this.GoodStandingTaxRate != null &&
                    this.GoodStandingTaxRate.Equals(input.GoodStandingTaxRate))
                ) && 
                (
                    this.NeutralStandingTaxRate == input.NeutralStandingTaxRate ||
                    (this.NeutralStandingTaxRate != null &&
                    this.NeutralStandingTaxRate.Equals(input.NeutralStandingTaxRate))
                ) && 
                (
                    this.BadStandingTaxRate == input.BadStandingTaxRate ||
                    (this.BadStandingTaxRate != null &&
                    this.BadStandingTaxRate.Equals(input.BadStandingTaxRate))
                ) && 
                (
                    this.TerribleStandingTaxRate == input.TerribleStandingTaxRate ||
                    (this.TerribleStandingTaxRate != null &&
                    this.TerribleStandingTaxRate.Equals(input.TerribleStandingTaxRate))
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
                if (this.OfficeId != null)
                    hashCode = hashCode * 59 + this.OfficeId.GetHashCode();
                if (this.SystemId != null)
                    hashCode = hashCode * 59 + this.SystemId.GetHashCode();
                if (this.ReinforceExitStart != null)
                    hashCode = hashCode * 59 + this.ReinforceExitStart.GetHashCode();
                if (this.ReinforceExitEnd != null)
                    hashCode = hashCode * 59 + this.ReinforceExitEnd.GetHashCode();
                if (this.CorporationTaxRate != null)
                    hashCode = hashCode * 59 + this.CorporationTaxRate.GetHashCode();
                if (this.AllowAllianceAccess != null)
                    hashCode = hashCode * 59 + this.AllowAllianceAccess.GetHashCode();
                if (this.AllianceTaxRate != null)
                    hashCode = hashCode * 59 + this.AllianceTaxRate.GetHashCode();
                if (this.AllowAccessWithStandings != null)
                    hashCode = hashCode * 59 + this.AllowAccessWithStandings.GetHashCode();
                if (this.StandingLevel != null)
                    hashCode = hashCode * 59 + this.StandingLevel.GetHashCode();
                if (this.ExcellentStandingTaxRate != null)
                    hashCode = hashCode * 59 + this.ExcellentStandingTaxRate.GetHashCode();
                if (this.GoodStandingTaxRate != null)
                    hashCode = hashCode * 59 + this.GoodStandingTaxRate.GetHashCode();
                if (this.NeutralStandingTaxRate != null)
                    hashCode = hashCode * 59 + this.NeutralStandingTaxRate.GetHashCode();
                if (this.BadStandingTaxRate != null)
                    hashCode = hashCode * 59 + this.BadStandingTaxRate.GetHashCode();
                if (this.TerribleStandingTaxRate != null)
                    hashCode = hashCode * 59 + this.TerribleStandingTaxRate.GetHashCode();
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
            // ReinforceExitStart (int?) maximum
            if(this.ReinforceExitStart > (int?)23)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ReinforceExitStart, must be a value less than or equal to 23.", new [] { "ReinforceExitStart" });
            }

            // ReinforceExitStart (int?) minimum
            if(this.ReinforceExitStart < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ReinforceExitStart, must be a value greater than or equal to 0.", new [] { "ReinforceExitStart" });
            }

            // ReinforceExitEnd (int?) maximum
            if(this.ReinforceExitEnd > (int?)23)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ReinforceExitEnd, must be a value less than or equal to 23.", new [] { "ReinforceExitEnd" });
            }

            // ReinforceExitEnd (int?) minimum
            if(this.ReinforceExitEnd < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ReinforceExitEnd, must be a value greater than or equal to 0.", new [] { "ReinforceExitEnd" });
            }

            yield break;
        }
    }

}

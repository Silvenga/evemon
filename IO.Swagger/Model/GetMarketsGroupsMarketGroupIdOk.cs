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
    public partial class GetMarketsGroupsMarketGroupIdOk :  IEquatable<GetMarketsGroupsMarketGroupIdOk>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMarketsGroupsMarketGroupIdOk" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetMarketsGroupsMarketGroupIdOk() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMarketsGroupsMarketGroupIdOk" /> class.
        /// </summary>
        /// <param name="marketGroupId">market_group_id integer (required).</param>
        /// <param name="name">name string (required).</param>
        /// <param name="description">description string (required).</param>
        /// <param name="types">types array (required).</param>
        /// <param name="parentGroupId">parent_group_id integer.</param>
        public GetMarketsGroupsMarketGroupIdOk(int? marketGroupId = default(int?), string name = default(string), string description = default(string), List<int?> types = default(List<int?>), int? parentGroupId = default(int?))
        {
            // to ensure "marketGroupId" is required (not null)
            if (marketGroupId == null)
            {
                throw new InvalidDataException("marketGroupId is a required property for GetMarketsGroupsMarketGroupIdOk and cannot be null");
            }
            else
            {
                this.MarketGroupId = marketGroupId;
            }
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for GetMarketsGroupsMarketGroupIdOk and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new InvalidDataException("description is a required property for GetMarketsGroupsMarketGroupIdOk and cannot be null");
            }
            else
            {
                this.Description = description;
            }
            // to ensure "types" is required (not null)
            if (types == null)
            {
                throw new InvalidDataException("types is a required property for GetMarketsGroupsMarketGroupIdOk and cannot be null");
            }
            else
            {
                this.Types = types;
            }
            this.ParentGroupId = parentGroupId;
        }
        
        /// <summary>
        /// market_group_id integer
        /// </summary>
        /// <value>market_group_id integer</value>
        [DataMember(Name="market_group_id", EmitDefaultValue=false)]
        public int? MarketGroupId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// types array
        /// </summary>
        /// <value>types array</value>
        [DataMember(Name="types", EmitDefaultValue=false)]
        public List<int?> Types { get; set; }

        /// <summary>
        /// parent_group_id integer
        /// </summary>
        /// <value>parent_group_id integer</value>
        [DataMember(Name="parent_group_id", EmitDefaultValue=false)]
        public int? ParentGroupId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetMarketsGroupsMarketGroupIdOk {\n");
            sb.Append("  MarketGroupId: ").Append(MarketGroupId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Types: ").Append(Types).Append("\n");
            sb.Append("  ParentGroupId: ").Append(ParentGroupId).Append("\n");
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
            return this.Equals(input as GetMarketsGroupsMarketGroupIdOk);
        }

        /// <summary>
        /// Returns true if GetMarketsGroupsMarketGroupIdOk instances are equal
        /// </summary>
        /// <param name="input">Instance of GetMarketsGroupsMarketGroupIdOk to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetMarketsGroupsMarketGroupIdOk input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.MarketGroupId == input.MarketGroupId ||
                    (this.MarketGroupId != null &&
                    this.MarketGroupId.Equals(input.MarketGroupId))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Types == input.Types ||
                    this.Types != null &&
                    this.Types.SequenceEqual(input.Types)
                ) && 
                (
                    this.ParentGroupId == input.ParentGroupId ||
                    (this.ParentGroupId != null &&
                    this.ParentGroupId.Equals(input.ParentGroupId))
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
                if (this.MarketGroupId != null)
                    hashCode = hashCode * 59 + this.MarketGroupId.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Types != null)
                    hashCode = hashCode * 59 + this.Types.GetHashCode();
                if (this.ParentGroupId != null)
                    hashCode = hashCode * 59 + this.ParentGroupId.GetHashCode();
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

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ContactManagement.Areas.Api.Models
{
    public class ContactModel
    {
        public ContactModel(Data.Entity.Contact entity)
        {
            this.ContactId = entity.ContactId;
            this.FirstName = entity.FirstName;
            this.MiddleName = entity.MiddleName;
            this.LastName = entity.LastName;
            this.CompanyName = entity.CompanyName;
            this.Address = entity.Address;
            this.Email = entity.Email;
            this.WorkPhone = entity.WorkPhone;
            this.CellPhone = entity.CellPhone;
            this.Category = new CategoryModel(entity.Category);
            this.Birthdate = entity.Birthdate;
        }

        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string WorkPhone { get; set; }

        public string CellPhone { get; set; }

        public DateTime? Birthdate { get; set; }

        public CategoryModel Category { get; set; }
    }

    [DataContract]
    public class ContactPostModel
    {        
        [DataMember]
        [Required]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        [Required]
        public string LastName { get; set; }

        [DataMember]
        [Required]
        public string CompanyName { get; set; }

        [DataMember]
        [Required]
        public string Address { get; set; }

        [DataMember]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataMember]
        public string WorkPhone { get; set; }

        [DataMember]
        public string CellPhone { get; set; }

        [DataMember]
        public CategoryModel Category { get; set; }

        [DataMember]
        public DateTime? Birthdate { get; set; }

        public Data.Entity.Contact ToEntity()
        {
            return new Data.Entity.Contact
            {
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                CompanyName = this.CompanyName,
                Address = this.Address,
                Email = this.Email,
                WorkPhone = this.WorkPhone,
                CellPhone = this.CellPhone,
                Category = this.Category.ToEntity(),
                Birthdate = this.Birthdate
            };
        }
    }

    [DataContract]
    public class ContactPutModel
    {
        [DataMember]
        public int ContactId { get; set; }

        [DataMember]
        [Required]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        [Required]
        public string LastName { get; set; }

        [DataMember]
        [Required]
        public string CompanyName { get; set; }

        [DataMember]
        [Required]
        public string Address { get; set; }

        [DataMember]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataMember]
        public string WorkPhone { get; set; }

        [DataMember]
        public string CellPhone { get; set; }

        [DataMember]
        public CategoryModel Category { get; set; }

        [DataMember]
        public DateTime? Birthdate { get; set; }

        public Data.Entity.Contact ToEntity()
        {
            return new Data.Entity.Contact
            {
                ContactId = this.ContactId,
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                CompanyName = this.CompanyName,
                Address = this.Address,
                Email = this.Email,
                WorkPhone = this.WorkPhone,
                CellPhone = this.CellPhone,
                Category = this.Category.ToEntity(),
                Birthdate = this.Birthdate
            };
        }
    }
}
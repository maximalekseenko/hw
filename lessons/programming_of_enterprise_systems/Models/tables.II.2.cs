using System.ComponentModel.DataAnnotations.Schema;


namespace Program.Models.Tables
{
    public class Type
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }

    public class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
    }

    public class BuildingMaterial
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
    }

    public class RealEstateObject
    {
        public int ObjectId { get; set; }
        public int DistrictId { get; set; }
        public string Address { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public int TypeId { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int MaterialId { get; set; }
        public double Area { get; set; }
        public DateTime AnnouncementDate { get; set; }

        [ForeignKey("DistrictId")]
        public District District { get; set; }

        [ForeignKey("TypeId")]
        public Type Type { get; set; }

        [ForeignKey("MaterialId")]
        public BuildingMaterial BuildingMaterial { get; set; }
    }

    public class AssessmentCriterion
    {
        public int CriterionId { get; set; }
        public string CriterionName { get; set; }
    }

    public class Assessment
    {
        public int AssessmentId { get; set; }
        public int ObjectId { get; set; }
        public DateTime AssessmentDate { get; set; }
        public int CriterionId { get; set; }
        public int Mark { get; set; }

        [ForeignKey("ObjectId")]
        public RealEstateObject RealEstateObject { get; set; }

        [ForeignKey("CriterionId")]
        public AssessmentCriterion AssessmentCriterion { get; set; }
    }

    public class Realtor
    {
        public int RealtorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Sale
    {
        public int SaleId { get; set; }
        public int ObjectId { get; set; }
        public DateTime SaleDate { get; set; }
        public int RealtorId { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("ObjectId")]
        public RealEstateObject RealEstateObject { get; set; }

        [ForeignKey("RealtorId")]
        public Realtor Realtor { get; set; }
    }
}
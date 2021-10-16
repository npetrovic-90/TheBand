using BandAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Models
{
	[TitleAndDescriptionAttribute]
	public class AlbumForCreatingDto //: IValidatableObject
	{
		[Required]
		public string Title { get; set; }
		[MaxLength(400)]
		public string Description { get; set; }

		//public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		//{
		//	if(Title == Description)
		//	{
		//		yield return new ValidationResult("Title and Description need to be different!", new[] { "AlbumForCreatingDto" });
		//	}
		//}
	}
}

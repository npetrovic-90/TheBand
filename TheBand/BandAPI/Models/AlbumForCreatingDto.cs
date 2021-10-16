using BandAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Models
{
	[TitleAndDescription(ErrorMessage ="Title Must be Different from Description")]
	public class AlbumForCreatingDto //: IValidatableObject
	{
		[Required(ErrorMessage = "Title needs to be filled in")]
		[MaxLength(200,ErrorMessage ="Title needs to be up to 200 characters")]
		public string Title { get; set; }
		[MaxLength(400, ErrorMessage = "Description needs to be up to 400 characters")]
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

﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FPTApp.Models
{
	public class Course
	{
		public int Id { get; set; }

		[Required]
		[DisplayName("Course Name")]
		public string Name { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public int TopicId { get; set; }
		public Topic Topic { get; set; }

	}
}
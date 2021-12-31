using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models
{
	public class Books
	{
        public int Id { get; set; }

        [Required(ErrorMessage="Please add Title Property")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please add Description Property")]
        public string  Description { get; set; }
    }
}


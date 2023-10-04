using System;
using System.ComponentModel.DataAnnotations;

namespace CrudNet7.Models
{
	public class Contacto
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Nombre { get; set; }

		[Required]
        public string Celular { get; set; }

		
        public string Telefono { get; set; }

		[Required]
		public string Email { get; set; }


        public DateTime FechaCreacion { get; set; }



    }
}


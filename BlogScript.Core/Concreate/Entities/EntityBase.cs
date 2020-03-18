using System;
using System.Collections.Generic;
using System.Text;
using BlogScript.Core.Abstract.Entities;

namespace BlogScript.Core.Concreate.Entities
{
    public class EntityBase: IEntityBase
    {
		public int id { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.UtcNow;
		public int CreateUserid { get; set; } = 0;
		public DateTime? UpdateDate { get; set; }
		public int? UpdateUserid { get; set; }
		public bool IsActive { get; set; } = true;

	}
}

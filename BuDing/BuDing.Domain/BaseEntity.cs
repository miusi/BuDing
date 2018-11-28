using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BuDing.Domain
{
    public abstract class BaseEntity:IEntity
    {
        protected BaseEntity()
        {
        }

        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [StringLength(20)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string ID { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        [StringLength(20)]
        public string CreateUserId { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        [StringLength(50)]
        public string CreateBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 更新人Id
        /// </summary>
        [StringLength(20)]
        public string ModifiedUserId { get; set; }

        /// <summary>
        /// 更新人名称
        /// </summary>
        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}

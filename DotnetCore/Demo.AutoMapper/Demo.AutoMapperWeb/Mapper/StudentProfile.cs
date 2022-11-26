using AutoMapper;
using Demo.AutoMapperWeb.Model;
using Demo.AutoMapperWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AutoMapperWeb.Mapper
{
    public class StudentProfile : Profile
    {
        /// <summary>
        /// 构造函数中实现映射
        /// </summary>
        public StudentProfile()
        {
            // Mapping
            // 第一次参数是源类型（这里是Model类型），第二个参数是目标类型（这里是DTO类型）
            CreateMap<Student, StudentVM>()
                .ForMember(des => des.StudentId, memberOption =>
                {
                    // 列名不相同时 匹配 studentID<=>id
                    memberOption.MapFrom(map => map.ID);
                })
                 .ForMember(des => des.StudentName, memberOption =>
                 {
                     // 列名不相同时 匹配 studentName<=>name
                     memberOption.MapFrom(map => map.Name);
                 })
                 //.ReverseMap()  //ReverseMap表示双向映射
                 ;
        }
    }
}

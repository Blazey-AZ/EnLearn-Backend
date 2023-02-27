// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using CloudinaryDotNet;
// using enlearn.Data;
// using enlearn.DTOs;
// using enlearn.Entities;
// using enlearn.Interfaces;

// namespace enlearn.Repository
// {
//     public class AccountRepository : IAccountRepository
//     {
//          private readonly DataContext _context;
//         public AccountRepository(DataContext context)
//         {
//             _context = context;
//         }
//         public IEnumerable<personaldetails> GetPersonalInfoAll()
//         {
//             var detailsList = (from d in _context.tblcap_personaldetails
//                               join rel in _context.tblcap_religion on d.religionid equals rel.religionid
//                               join st in _context.tblcap_state on d.stateid equals st.stateid
//                               join cas in _context.tblcap_caste on d.casteid equals cas.casteid
//                               join dist in _context.tblcap_district on d.districtid equals dist.districtid
//                               join stu in _context.tblcap_basicdetails on d.studentid equals stu.studentid

//                               select new PersonalDetailsDto()
//                               {
//                                 PersonalID = d.personalid,
//                                 StudentName = stu.studentname,
//                                 Image = d.image,
//                                 NameOfFather = d.nameoffather,
//                                 DateOfBirth = d.dateofbirth,
//                                 Nationality = d.nationality,
//                                 AnnualIncome = d.annualincome,
//                                 ReligionName = rel.religionname,
//                                 CasteName = cas.castename,
//                                 StateName = st.statename,
//                                 DistrictName = dist.districtname,
//                                 Pincode = d.pincode,
//                                 Email = d.email
//                               }).ToList();

//                               return detailsList;
//         }
//     }
// }
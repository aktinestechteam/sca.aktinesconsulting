using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.repository.Common
{
    public class ConstantStoredProcedures
    {
        public const string SCAExceptionFields_GetAll = "SCAExceptionFields_GetAll";
        public const string SCAExceptionFields_AddUpdate = "SCAExceptionFields_AddUpdate";
        public const string SCAExceptionFields_Delete = "SCAExceptionFields_Delete";
        public const string SCAExceptionFields_GetBySCAExceptionFieldTypeId = "SCAExceptionFields_GetBySCAExceptionFieldTypeId";
        public const string SCAExceptionFieldTypes_GetAll = "SCAExceptionFieldTypes_GetAll";
        public const string SCAExceptions_GetAll = "SCAExceptions_GetAll";
        public const string SCAExceptions_GetById = "SCAExceptions_GetById";
        public const string SCAExceptions_Add = "SCAExceptions_Add";
        public const string SCAExceptions_Update = "SCAExceptions_Update";
        public const string SCAExceptions_Delete = "SCAExceptions_Delete";
        public const string SCAVersions_Add = "SCAVersions_Add";
        public const string SCAVersions_GetAll = "SCAVersions_GetAll";
        public const string BookingEntries_GetBySCAVersionId = "BookingEntries_GetBySCAVersionId";
        public const string Permissions_GetByUserId = "Permissions_GetByUserId";
        public const string BookingEntries_GetByDate = "BookingEntries_GetByDate";
        public const string BookingEntries_UpdateEmailDetails = "BookingEntries_UpdateEmailDetails";
        public const string BookingEntries_GetByAWB = "BookingEntries_GetByAWB";
        public const string LastBookingEntries_Delete = "LastBookingEntries_Delete";
        public const string LastBookingEntries_GetDuplicates = "LastBookingEntries_GetDuplicates";
        public const string LastBookingEntries_Get = "LastBookingEntries_Get";
        public const string LastBookingEntries_IsExist = "LastBookingEntries_IsExist";
        public const string LastBookingVersions_Get = "LastBookingVersions_Get";
        public const string LastBookingEntries_UpdateIsConsidered = "LastBookingEntries_UpdateIsConsidered";
        public const string Report_GetOutlierReport = "Report_GetOutlierReport";



        //Tables
        public const string Table_BookingEntries = "BookingEntries";
        public const string Table_LastBookingEntries = "LastBookingEntries";
    }
}

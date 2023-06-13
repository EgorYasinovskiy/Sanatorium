/* eslint-disable */
/* tslint:disable */
/*
 * ---------------------------------------------------------------
 * ## THIS FILE WAS GENERATED VIA SWAGGER-TYPESCRIPT-API        ##
 * ##                                                           ##
 * ## AUTHOR: acacode                                           ##
 * ## SOURCE: https://github.com/acacode/swagger-typescript-api ##
 * ---------------------------------------------------------------
 */

export interface InvoiceDTO {
  /** @format guid */
  parentId?: string;
  /** @format date */
  dateFrom?: string;
  /** @format guid */
  id?: string;
  items?: InvoiceItemDTO[];
  payed?: boolean;
  /** @format date-time */
  payDate?: string;
}

export interface InvoiceItemDTO {
  /** @format guid */
  id?: string;
  /** @format guid */
  invoiceId?: string;
  name?: string;
  /** @format int32 */
  quanitity?: number;
  /** @format double */
  price?: number;
  /** @format double */
  sum?: number;
}

export interface ProblemDetails {
  type?: string | null;
  title?: string | null;
  /** @format int32 */
  status?: number | null;
  detail?: string | null;
  instance?: string | null;
  [key: string]: any;
}

export interface StaffList {
  staff?: StaffListItem[];
}

export interface StaffListItem {
  /** @format guid */
  id?: string;
  firstName?: string;
  middleName?: string;
  lastName?: string;
  /** @format date */
  birthDate?: string;
  phoneNumber?: string;
}

export interface StaffDTO {
  /** @format guid */
  id?: string;
  firstName?: string;
  lastName?: string;
  middleName?: string;
  /** @format date */
  birthDate?: string;
  phoneNumber?: string;
  /** @format int32 */
  cabinetNumber?: number;
  position?: string;
  /** @format guid */
  managerId?: string;
  managerName?: string;
  /** @format int32 */
  dayWork?: number;
  /** @format int32 */
  dayHoliday?: number;
  /** @format date */
  workStart?: string;
  /** @format double */
  salaryPerHour?: number;
}

export interface PaymentInfo {
  staffName?: string;
  period?: string;
  /** @format double */
  sum?: number;
  paymentInfoByDate?: Record<string, PaymentInfoItem>;
}

export interface PaymentInfoItem {
  /** @format double */
  hours?: number;
  /** @format double */
  salary?: number;
}

export interface PaymentShortInfo {
  /** @format date */
  periodStart?: string;
  /** @format date */
  periodEnd?: string;
  payments?: PaymentShortInfoItem[];
}

export interface PaymentShortInfoItem {
  staffName?: string;
  /** @format double */
  payment?: number;
}

export interface ChangeManager {
  /** @format guid */
  staffId?: string;
  /** @format guid */
  newManagerId?: string;
}

export interface ChangePosition {
  /** @format guid */
  staffId?: string;
  newPosition?: string;
}

export interface ChangeSalary {
  /** @format guid */
  staffId?: string;
  /** @format double */
  newSalaryPerHour?: number;
}

export interface ChangeSchedule {
  /** @format guid */
  staffId?: string;
  /** @format int32 */
  dayWork?: number;
  /** @format int32 */
  dayHoliday?: number;
  /** @format date */
  dateStart?: string;
}

export interface ChangeCabinet {
  /** @format guid */
  staffId?: string;
  /** @format int32 */
  newCabinet?: number;
}

export interface UpdateStaffDTO {
  /** @format guid */
  id?: string;
  firstName?: string;
  middleName?: string;
  lastName?: string;
  phoneNumber?: string;
  /** @format date */
  birthdate?: string;
}

export interface CreateStaffDTO {
  firstName?: string;
  middleName?: string;
  lastName?: string;
  phoneNumber?: string;
  /** @format date */
  birthDate?: string;
  position?: string;
  /** @format int32 */
  dayWork?: number;
  /** @format int32 */
  dayHoliday?: number;
  /** @format date */
  workStart?: string;
  /** @format guid */
  managerId?: string;
  /** @format double */
  salaryPerHour?: number;
}

export interface StaffWorkRecordsDTO {
  workRecords?: StaffWorkRecordsItem[];
}

export interface StaffWorkRecordsItem {
  /** @format guid */
  id?: string;
  /** @format date */
  date?: string;
  /** @format double */
  hours?: number;
}

export interface AddWorkTime {
  /** @format guid */
  staffId?: string;
  /** @format double */
  hours?: number;
  /** @format date */
  date?: string;
}

export interface UpdateWorkTime {
  /** @format guid */
  recordId?: string;
  /** @format double */
  hours?: number;
  /** @format date */
  date?: string;
}

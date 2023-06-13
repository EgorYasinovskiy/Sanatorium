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

export interface PatientList {
  patients?: PatientListItem[];
}

export interface PatientListItem {
  /** @format guid */
  id?: string;
  firstName?: string;
  lastName?: string;
  middleName?: string;
}

export interface PatientDTO {
  /** @format guid */
  id?: string;
  firstName?: string;
  lastName?: string;
  middleName?: string;
  /** @format date */
  birthDate?: string;
  phoneNumber?: string;
  /** @format date */
  dateRegistered?: string;
  /** @format date */
  dateDischarged?: string | null;
  discharged?: boolean;
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

export interface CreatePatientDTO {
  firstName?: string;
  lastName?: string;
  middleName?: string;
  phoneNumber?: string;
  /** @format date */
  birthDate?: string;
}

export interface PatientUpdateDTO {
  /** @format guid */
  id?: string;
  firstName?: string;
  lastName?: string;
  middleName?: string;
  /** @format date */
  birthDate?: string;
  phoneNumber?: string;
}

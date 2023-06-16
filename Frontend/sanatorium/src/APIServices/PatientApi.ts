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

import { CreatePatientDTO, PatientDTO, PatientList, PatientUpdateDTO, ProblemDetails } from "./PatientDataContract";
import { ContentType, HttpClient, RequestParams } from "./http-client";

export class PatientServiceApi<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags Patient
   * @name PatientGetAll
   * @request GET:/api/Patient
   */
  patientGetAll = (params: RequestParams = {}) =>
    this.request<PatientList, any>({
      path: `/api/Patient`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Patient
   * @name PatientRegisterNew
   * @request POST:/api/Patient
   */
  patientRegisterNew = (data: CreatePatientDTO, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/Patient`,
      method: "POST",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Patient
   * @name PatientUpdate
   * @request PUT:/api/Patient
   */
  patientUpdate = (data: PatientUpdateDTO, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/Patient`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Patient
   * @name PatientGet
   * @request GET:/api/Patient/{id}
   */
  patientGet = (id: string, params: RequestParams = {}) =>
    this.request<PatientDTO, ProblemDetails>({
      path: `/api/Patient/${id}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Patient
   * @name PatientRegister
   * @request PUT:/api/Patient/{id}/register
   */
  patientRegister = (id: string, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/Patient/${id}/register`,
      method: "PUT",
      ...params,
    });
  /**
   * No description
   *
   * @tags Patient
   * @name PatientDischarge
   * @request PUT:/api/Patient/{id}/discharge
   */
  patientDischarge = (id: string, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/Patient/${id}/discharge`,
      method: "PUT",
      ...params,
    });
}

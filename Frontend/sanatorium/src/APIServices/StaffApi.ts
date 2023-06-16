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

import {
  AddWorkTime,
  ChangeCabinet,
  ChangeManager,
  ChangePosition,
  ChangeSalary,
  ChangeSchedule,
  CreateStaffDTO,
  InvoiceDTO,
  PaymentInfo,
  PaymentShortInfo,
  ProblemDetails,
  StaffDTO,
  StaffList,
  StaffWorkRecordsDTO,
  UpdateStaffDTO,
  UpdateWorkTime,
} from "./StaffServiceDataContract";
import { ContentType, HttpClient, RequestParams } from "./http-client";

export class StaffApi<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags ReportControlelr
   * @name ReportControlelrGetStaffInvoice
   * @request GET:/api/ReportControlelr/invoice/{staffId}/{date}
   */
  reportControlelrGetStaffInvoice = (staffId: string, date: string, params: RequestParams = {}) =>
    this.request<InvoiceDTO, ProblemDetails>({
      path: `/api/ReportControlelr/invoice/${staffId}/${date}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffGetAllStaff
   * @request GET:/api/Staff
   */
  staffGetAllStaff = (params: RequestParams = {}) =>
    this.request<StaffList, any>({
      path: `/api/Staff`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffUpdate
   * @request PUT:/api/Staff
   */
  staffUpdate = (data: UpdateStaffDTO, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Staff`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffCreate
   * @request POST:/api/Staff
   */
  staffCreate = (data: CreateStaffDTO, params: RequestParams = {}) =>
    this.request<StaffDTO, any>({
      path: `/api/Staff`,
      method: "POST",
      body: data,
      type: ContentType.Json,
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffGetStaff
   * @request GET:/api/Staff/{id}
   */
  staffGetStaff = (id: string, params: RequestParams = {}) =>
    this.request<StaffDTO, ProblemDetails>({
      path: `/api/Staff/${id}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffDelete
   * @request DELETE:/api/Staff/{id}
   */
  staffDelete = (id: string, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Staff/${id}`,
      method: "DELETE",
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffGetPayemnts
   * @request GET:/api/Staff/{id}/payments/{periodStart}/{periodEnd}
   */
  staffGetPayemnts = (id: string, periodStart: string, periodEnd: string, params: RequestParams = {}) =>
    this.request<PaymentInfo, ProblemDetails>({
      path: `/api/Staff/${id}/payments/${periodStart}/${periodEnd}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffGetAllPayments
   * @request GET:/api/Staff/payments/{periodStart}/{periodEnd}
   */
  staffGetAllPayments = (periodStart: string, periodEnd: string, params: RequestParams = {}) =>
    this.request<PaymentShortInfo, ProblemDetails>({
      path: `/api/Staff/payments/${periodStart}/${periodEnd}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffChangeManager
   * @request PUT:/api/Staff/manager
   */
  staffChangeManager = (data: ChangeManager, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Staff/manager`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffChangeManager2
   * @request PUT:/api/Staff/position
   */
  changePosition = (data: ChangePosition, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Staff/position`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffChangeSalary
   * @request PUT:/api/Staff/salary
   */
  staffChangeSalary = (data: ChangeSalary, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Staff/salary`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffChangeSchedule
   * @request PUT:/api/Staff/schedule
   */
  staffChangeSchedule = (data: ChangeSchedule, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Staff/schedule`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Staff
   * @name StaffChangeCabinet
   * @request PUT:/api/Staff/cabinet
   */
  staffChangeCabinet = (data: ChangeCabinet, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Staff/cabinet`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags WorkRecord
   * @name WorkRecordGet
   * @request GET:/api/WorkRecord/{id}
   */
  workRecordGet = (id: string, params: RequestParams = {}) =>
    this.request<StaffWorkRecordsDTO, ProblemDetails>({
      path: `/api/WorkRecord/${id}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags WorkRecord
   * @name WorkRecordDelete
   * @request DELETE:/api/WorkRecord/{id}
   */
  workRecordDelete = (id: string, params: RequestParams = {}) =>
    this.request<File, any>({
      path: `/api/WorkRecord/${id}`,
      method: "DELETE",
      ...params,
    });
  /**
   * No description
   *
   * @tags WorkRecord
   * @name WorkRecordCreate
   * @request POST:/api/WorkRecord
   */
  workRecordCreate = (data: AddWorkTime, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/WorkRecord`,
      method: "POST",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags WorkRecord
   * @name WorkRecordUpdate
   * @request PUT:/api/WorkRecord
   */
  workRecordUpdate = (data: UpdateWorkTime, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/WorkRecord`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
}

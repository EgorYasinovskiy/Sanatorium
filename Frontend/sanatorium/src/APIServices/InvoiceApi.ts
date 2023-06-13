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

import { InvoiceDTO, ProblemDetails } from "./InvoiceDataContract";
import { ContentType, HttpClient, RequestParams } from "./http-client";

export class InvoiceApi<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags Report
   * @name ReportGetPatientInvoice
   * @request GET:/api/Report/patient/{patientId}/{dateFrom}
   */
  reportGetPatientInvoice = (
    patientId: string,
    dateFrom: string,
    data: string,
    query?: {
      refreshData?: boolean;
    },
    params: RequestParams = {},
  ) =>
    this.request<InvoiceDTO, ProblemDetails>({
      path: `/api/Report/patient/${patientId}/${dateFrom}`,
      method: "GET",
      query: query,
      body: data,
      type: ContentType.Json,
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Report
   * @name ReportGetStaffInvoice
   * @request GET:/api/Report/staff/{staffId}/{dateFrom}
   */
  reportGetStaffInvoice = (staffId: string, dateFrom: string, data: string, params: RequestParams = {}) =>
    this.request<InvoiceDTO, ProblemDetails>({
      path: `/api/Report/staff/${staffId}/${dateFrom}`,
      method: "GET",
      body: data,
      type: ContentType.Json,
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Report
   * @name ReportGetInventoryInvoice
   * @request GET:/api/Report/inventory/{dateFrom}
   */
  reportGetInventoryInvoice = (dateFrom: string, data: string, params: RequestParams = {}) =>
    this.request<InvoiceDTO, ProblemDetails>({
      path: `/api/Report/inventory/${dateFrom}`,
      method: "GET",
      body: data,
      type: ContentType.Json,
      format: "json",
      ...params,
    });
}

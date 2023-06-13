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
  CreateItemDTO,
  CreateRecordDTO,
  InventoryItemDTO,
  InventoryItemListDTO,
  InventoryRecordDTO,
  InventoryRecordListDTO,
  InventoryResumeDTO,
  InvoiceDTO,
  ProblemDetails,
  UpdateItemDTO,
  UpdateRecordDTO,
} from "./InventoryDataContract";
import { ContentType, HttpClient, RequestParams } from "./http-client";

export class InventoryAPI<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags Items
   * @name ItemsGetAll
   * @request GET:/api/Items
   */
  itemsGetAll = (params: RequestParams = {}) =>
    this.request<InventoryItemListDTO, any>({
      path: `/api/Items`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Items
   * @name ItemsCreate
   * @request POST:/api/Items
   */
  itemsCreate = (data: CreateItemDTO, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Items`,
      method: "POST",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Items
   * @name ItemsUpdate
   * @request PUT:/api/Items
   */
  itemsUpdate = (data: UpdateItemDTO, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/Items`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Items
   * @name ItemsGetById
   * @request GET:/api/Items/{id}
   */
  itemsGetById = (id: string, params: RequestParams = {}) =>
    this.request<InventoryItemDTO, ProblemDetails>({
      path: `/api/Items/${id}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Items
   * @name ItemsDelete
   * @request DELETE:/api/Items/{id}
   */
  itemsDelete = (id: string, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/Items/${id}`,
      method: "DELETE",
      ...params,
    });
  /**
   * No description
   *
   * @tags Items
   * @name ItemsGetResume
   * @request GET:/api/Items/resume
   */
  itemsGetResume = (params: RequestParams = {}) =>
    this.request<InventoryResumeDTO, any>({
      path: `/api/Items/resume`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Items
   * @name ItemsGetMissing
   * @request GET:/api/Items/missing
   */
  itemsGetMissing = (params: RequestParams = {}) =>
    this.request<InventoryItemListDTO, any>({
      path: `/api/Items/missing`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Records
   * @name RecordsGetByDateRange
   * @request GET:/api/Records/{start}/{end}
   */
  recordsGetByDateRange = (start: string, end: string, params: RequestParams = {}) =>
    this.request<InventoryRecordListDTO, any>({
      path: `/api/Records/${start}/${end}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Records
   * @name RecordsGetByItemId
   * @request GET:/api/Records/byItem/{id}
   */
  recordsGetByItemId = (id: string, params: RequestParams = {}) =>
    this.request<InventoryRecordListDTO, any>({
      path: `/api/Records/byItem/${id}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Records
   * @name RecordsGetById
   * @request GET:/api/Records/{id}
   */
  recordsGetById = (id: string, params: RequestParams = {}) =>
    this.request<InventoryRecordDTO, ProblemDetails>({
      path: `/api/Records/${id}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Records
   * @name RecordsDelete
   * @request DELETE:/api/Records/{id}
   */
  recordsDelete = (id: string, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/Records/${id}`,
      method: "DELETE",
      ...params,
    });
  /**
   * No description
   *
   * @tags Records
   * @name RecordsCreate
   * @request POST:/api/Records
   */
  recordsCreate = (data: CreateRecordDTO, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Records`,
      method: "POST",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Records
   * @name RecordsUpdate
   * @request PUT:/api/Records
   */
  recordsUpdate = (data: UpdateRecordDTO, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/Records`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Report
   * @name ReportGetInvoice
   * @request GET:/api/Report/invoice
   */
  reportGetInvoice = (params: RequestParams = {}) =>
    this.request<InvoiceDTO, any>({
      path: `/api/Report/invoice`,
      method: "GET",
      format: "json",
      ...params,
    });
}

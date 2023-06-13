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

export interface InventoryItemListDTO {
  items?: InventoryItemDTO[];
}

export interface InventoryItemDTO {
  /** @format guid */
  id?: string;
  /** @format double */
  price?: number;
  name?: string;
  /** @format int32 */
  quantity?: number;
  /** @format int32 */
  requiredQuantity?: number;
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

export interface InventoryResumeDTO {
  items?: InventoryItemShortDTO[];
}

export interface InventoryItemShortDTO {
  /** @format guid */
  id?: string;
  name?: string;
  /** @format int32 */
  needToBuy?: number;
  /** @format double */
  totalSum?: number;
}

export interface CreateItemDTO {
  /** @format double */
  price?: number;
  name?: string;
  /** @format int32 */
  quantity?: number;
  /** @format int32 */
  requiredQuantity?: number;
}

export interface UpdateItemDTO {
  /** @format guid */
  id?: string;
  /** @format double */
  price?: number;
  name?: string;
  /** @format int32 */
  quantity?: number;
  /** @format int32 */
  requiredQuantity?: number;
}

export interface InventoryRecordListDTO {
  inventoryRecords?: InventoryRecordDTO[];
}

export interface InventoryRecordDTO {
  /** @format guid */
  id?: string;
  item?: InventoryItemDTO;
  /** @format int32 */
  quantity?: number;
  recordType?: RecordType;
  /** @format date-time */
  dateTime?: string;
}

export enum RecordType {
  Receiving = 0,
  Sending = 1,
}

export interface CreateRecordDTO {
  /** @format guid */
  itemId?: string;
  /** @format int32 */
  quantity?: number;
  recordType?: RecordType;
  /** @format date-time */
  dateTime?: string;
}

export interface UpdateRecordDTO {
  /** @format guid */
  id?: string;
  /** @format guid */
  itemId?: string;
  /** @format int32 */
  quantity?: number;
  recordType?: RecordType;
  /** @format date-time */
  dateTime?: string;
}

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

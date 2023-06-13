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

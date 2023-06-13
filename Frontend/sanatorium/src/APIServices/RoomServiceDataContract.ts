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

export interface BookingList {
  bookings?: BookingDTO[];
}

export interface BookingDTO {
  /** @format guid */
  id?: string;
  /** @format guid */
  roomId?: string;
  /** @format int32 */
  roomNumber?: number;
  /** @format date */
  arrivalDate?: string;
  /** @format int32 */
  durationInDays?: number;
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

export interface CreateBookingDTO {
  /** @format guid */
  roomId?: string;
  /** @format date */
  arrivalDate?: string;
  /** @format int32 */
  durationInDays?: number;
}

export interface UpdateBookingDTO {
  /** @format guid */
  id?: string;
  /** @format guid */
  roomId?: string;
  /** @format date */
  arrivalDate?: string;
  /** @format int32 */
  durationInDays?: number;
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

export interface RoomMoveList {
  roomMoves?: RoomMoveDTO[];
}

export interface RoomMoveDTO {
  /** @format guid */
  id?: string;
  /** @format guid */
  patientId?: string;
  /** @format int32 */
  roomNumber?: number;
  /** @format guid */
  roomId?: string;
  /** @format date */
  date?: string;
  moveType?: RoomMoveType;
}

export enum RoomMoveType {
  Settlement = 1,
  Eviction = 2,
}

export interface CreateRoomMoveDTO {
  /** @format guid */
  patientId?: string;
  /** @format guid */
  room?: string;
  /** @format date */
  date?: string;
  moveType?: RoomMoveType;
}

export interface UpdateRoomMoveDTO {
  /** @format guid */
  id?: string;
  /** @format guid */
  patientId?: string;
  /** @format guid */
  roomId?: string;
  /** @format date */
  date?: string;
  moveType?: RoomMoveType;
}

export interface RoomListDTO {
  rooms?: RoomDTO[];
}

export interface RoomDTO {
  /** @format guid */
  id?: string;
  /** @format int32 */
  roomNumber?: number;
  /** @format int32 */
  bedsCount?: number;
  isFree?: boolean;
  /** @format double */
  costPerDay?: number;
  /** @format int32 */
  category?: number;
}

export interface CreateRoomDTO {
  /** @format int32 */
  category?: number;
  /** @format int32 */
  bedsCount?: number;
  /** @format int32 */
  roomNumber?: number;
  /** @format double */
  costPerDay?: number;
}

export interface UpdateRoomDTO {
  /** @format guid */
  id?: string;
  /** @format int32 */
  category?: number;
  /** @format int32 */
  bedsCount?: number;
  /** @format int32 */
  roomNumber?: number;
  isFree?: boolean;
  /** @format double */
  costPerDay?: number;
}

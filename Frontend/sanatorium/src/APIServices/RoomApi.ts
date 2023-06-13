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
  BookingDTO,
  BookingList,
  CreateBookingDTO,
  CreateRoomDTO,
  CreateRoomMoveDTO,
  InvoiceDTO,
  ProblemDetails,
  RoomListDTO,
  RoomMoveList,
  UpdateBookingDTO,
  UpdateRoomDTO,
  UpdateRoomMoveDTO,
} from "./RoomServiceDataContract";
import { ContentType, HttpClient, RequestParams } from "./http-client";

export class RoomApi<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags Bookings
   * @name BookingsGetAll
   * @request GET:/api/Bookings
   */
  bookingsGetAll = (params: RequestParams = {}) =>
    this.request<BookingList, any>({
      path: `/api/Bookings`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Bookings
   * @name BookingsCreateNew
   * @request POST:/api/Bookings
   */
  bookingsCreateNew = (data: CreateBookingDTO, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Bookings`,
      method: "POST",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Bookings
   * @name BookingsUpdate
   * @request PUT:/api/Bookings
   */
  bookingsUpdate = (data: UpdateBookingDTO, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Bookings`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Bookings
   * @name BookingsGetActual
   * @request GET:/api/Bookings/actual
   */
  bookingsGetActual = (params: RequestParams = {}) =>
    this.request<BookingList, any>({
      path: `/api/Bookings/actual`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Bookings
   * @name BookingsGetById
   * @request GET:/api/Bookings/{id}
   */
  bookingsGetById = (id: string, params: RequestParams = {}) =>
    this.request<BookingDTO, ProblemDetails>({
      path: `/api/Bookings/${id}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Bookings
   * @name BookingsDelete
   * @request DELETE:/api/Bookings/{id}
   */
  bookingsDelete = (id: string, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Bookings/${id}`,
      method: "DELETE",
      ...params,
    });
  /**
   * No description
   *
   * @tags Report
   * @name ReportGetInvoice
   * @request GET:/api/Report/invoice/{patientId}/{fromDate}
   */
  reportGetInvoice = (patientId: string, fromDate: string, params: RequestParams = {}) =>
    this.request<InvoiceDTO, any>({
      path: `/api/Report/invoice/${patientId}/${fromDate}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags RoomMoves
   * @name RoomMovesGetRoomMoves
   * @request GET:/api/RoomMoves/byDateRange/{patientId}
   */
  roomMovesGetRoomMoves = (
    patientId: string,
    start: string,
    end: string,
    params: RequestParams = {},
  ) =>
    this.request<RoomMoveList, any>({
      path: `/api/RoomMoves/byDateRange/${patientId}?start=${start}&end=${end}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags RoomMoves
   * @name RoomMovesGet
   * @request GET:/api/RoomMoves/{id}
   */
  roomMovesGet = (id: string, params: RequestParams = {}) =>
    this.request<RoomMoveList, any>({
      path: `/api/RoomMoves/${id}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags RoomMoves
   * @name RoomMovesDelete
   * @request DELETE:/api/RoomMoves/{id}
   */
  roomMovesDelete = (id: string, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/RoomMoves/${id}`,
      method: "DELETE",
      ...params,
    });
  /**
   * No description
   *
   * @tags RoomMoves
   * @name RoomMovesCreate
   * @request POST:/api/RoomMoves
   */
  roomMovesCreate = (data: CreateRoomMoveDTO, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/RoomMoves`,
      method: "POST",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags RoomMoves
   * @name RoomMovesUpdate
   * @request PUT:/api/RoomMoves
   */
  roomMovesUpdate = (data: UpdateRoomMoveDTO, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/RoomMoves`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Rooms
   * @name RoomsGet
   * @request GET:/api/Rooms
   */
  roomsGet = (params: RequestParams = {}) =>
    this.request<RoomListDTO, any>({
      path: `/api/Rooms`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Rooms
   * @name RoomsCreate
   * @request POST:/api/Rooms
   */
  roomsCreate = (data: CreateRoomDTO, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Rooms`,
      method: "POST",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Rooms
   * @name RoomsUpdate
   * @request PUT:/api/Rooms
   */
  roomsUpdate = (data: UpdateRoomDTO, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Rooms`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags Rooms
   * @name RoomsGetFree
   * @request GET:/api/Rooms/free
   */
  roomsGetFree = (params: RequestParams = {}) =>
    this.request<RoomListDTO, any>({
      path: `/api/Rooms/free`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Rooms
   * @name RoomsGet2
   * @request GET:/api/Rooms/{id}
   */
  roomsGet2 = (id: string, params: RequestParams = {}) =>
    this.request<RoomListDTO, ProblemDetails>({
      path: `/api/Rooms/${id}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags Rooms
   * @name RoomsDelete
   * @request DELETE:/api/Rooms/{id}
   */
  roomsDelete = (id: string, params: RequestParams = {}) =>
    this.request<void, ProblemDetails>({
      path: `/api/Rooms/${id}`,
      method: "DELETE",
      ...params,
    });
}

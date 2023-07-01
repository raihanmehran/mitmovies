export interface ResponsePagination {
  dates: [
    {
      maximum: Date;
      minimum: Date;
    }
  ];
  page: number;
  totalPages: number;
  totalResults: number;
}

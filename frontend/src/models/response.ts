export interface ApiResponse<T> {
    success:boolean,
    data:T | null,
    errorMessage?:string,
    errors?:string[]
}
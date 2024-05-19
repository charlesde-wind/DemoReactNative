type ActionSuccess<T> = {
    data: T
    success:true
}

type ActionFailure = {
    success:false
}

export type ActionResponse<T> = ActionFailure | ActionSuccess<T>
export type MaybePromise<T> = Promise<T> | T;
import { useState } from "react";

export const useAsyncFunction = <T extends (...args: any[]) => Promise<any>>(
  asyncFunction: T
) => {
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

  const wrappedFunction = async (...args: Parameters<T>) => {
    let callResult;
    setIsLoading(true);
    try {
      callResult = await asyncFunction(...args);
    } catch (e: any) {
      setErrorMessage(e.toString());
    }
    setIsLoading(false);
    return callResult;
  };

  return [wrappedFunction, { isLoading, errorMessage }];
};

interface AsyncStateProps {
  errorMessage?: string;
  isLoading: boolean;
}

export const joinAsyncState = (props: AsyncStateProps[]): AsyncStateProps => {
  const isLoadingStates = props.map((prop) => prop.isLoading);
  const errorMessageStates = props
    .filter((prop) => prop.errorMessage)
    .map((prop) => prop.errorMessage);

  return {
    isLoading: isLoadingStates.some((x) => x),
    errorMessage: errorMessageStates.join("\n"),
  };
};

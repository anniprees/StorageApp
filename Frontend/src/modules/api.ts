import { ref, Ref } from 'vue';

export type ApiRequest = () => Promise<void>;

export interface UsableAPI<T> {
  response: Ref<T | undefined>;
  request: ApiRequest;
}

let apiUrl = '';

export function setApiUrl(url: string) {
  apiUrl = url;
}

export default function useApi<T>(
  url: RequestInfo,
  options?: RequestInit,
): UsableAPI<T> {
  const response: Ref<T | undefined> = ref();

  const request: ApiRequest = async () => {
    const resp = await fetch(apiUrl + url, options);
    const data = await resp.json();
    response.value = data;
  };

  return { response, request };
}

export function useApiRawRequest(url: RequestInfo, options?: RequestInit) {
  const request: () => Promise<Response> = async () => {
    return await fetch(apiUrl + url, options);
  };
  return request;
}

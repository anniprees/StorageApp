import { reactive, toRefs } from 'vue';
import useApi, { useApiRawRequest } from './api';

export interface StorageLocation {
  id: number;
  name: string;
}

let storageLocations: StorageLocation[] = [];

export interface State {
  storageLocations: StorageLocation[];
}

const state = reactive<State>({
  storageLocations: [],
});

let initialized = false;

export default function useStorageLocation() {
  const apiGetStorageLocations = useApi<StorageLocation[]>('StorageLocations');
  const loadStorageLocations = async () => {
    if (!initialized) {
      await apiGetStorageLocations.request();

      if (apiGetStorageLocations.response.value) {
        storageLocations = apiGetStorageLocations.response.value!;
        state.storageLocations = storageLocations;
      }
      initialized = true;
    }
  };

  const addStorageLocation = async (storageLocation: StorageLocation) => {
    const apiAddStorageLocation = useApi<StorageLocation>('StorageLocations', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(storageLocation),
    });
    await apiAddStorageLocation.request();

    if (apiAddStorageLocation.response.value) {
      storageLocations.push(apiAddStorageLocation.response.value!);
      state.storageLocations = storageLocations;
    }
  };

  return { ...toRefs(state), loadStorageLocations, addStorageLocation };
}

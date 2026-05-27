export interface ProductState {

  products: any[];

  loading: boolean;

  error: string | null;

}

export const initialState: ProductState = {

  products: [],

  loading: false,

  error: null

};
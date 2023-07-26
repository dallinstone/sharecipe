import {createContext, useContext} from "react";
import CommonStore from "./commonStore";
import DrawerStore from "./drawerStore";
import UserStore from "./userStore";


interface Store {
    commonStore: CommonStore;
    drawerStore: DrawerStore;
    userStore: UserStore;
}

export const store: Store = {
    commonStore: new CommonStore(),
    drawerStore: new DrawerStore(),
    userStore: new UserStore(),
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}
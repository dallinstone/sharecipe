import { Box, Drawer } from "@mui/material"
import { useStore } from "../../../app/stores/store";
import DrawerList from "./DrawerList";
import { observer } from "mobx-react-lite";

export default observer(function ResponsiveDrawer() {

    const { commonStore, drawerStore } = useStore();
    const { mobileOpen, setMobileOpen } = commonStore;
    const { drawerWidth } = drawerStore;

    const handleDrawerToggle = () => {
        setMobileOpen(!mobileOpen);
    };

    return (
        <div>
            <Box
                component="nav"
                sx={{ width: { sm: drawerWidth }, flexShrink: { sm: 0 } }}
                aria-label="mailbox folders"
            >
                <Drawer
                    variant="temporary"
                    open={mobileOpen}
                    onClose={handleDrawerToggle}
                    ModalProps={{
                        keepMounted: true, // Better open performance on mobile.
                    }}
                    sx={{
                        display: { xs: 'block', sm: 'none' },
                        '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth },
                    }}
                >
                    <DrawerList />
                </Drawer>
                <Drawer
                    variant="permanent"
                    sx={{
                        display: { xs: 'none', sm: 'block' },
                        '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth },
                    }}
                    open
                >
                    <DrawerList />
                </Drawer>
            </Box>
        </div>
    )
}
)
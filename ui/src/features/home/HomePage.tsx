import Box from '@mui/material/Box';
import HeaderBar from './HomeHeaderBar';
import HomePageBody from './HomePageBody';
import ResponsiveDrawer from '../navbars/leftnavbar/ResponsiveDrawer';
import { observer } from 'mobx-react-lite';

export default observer(function HomePage() {
  return (
    <>
      <HeaderBar />
      <Box sx={{ display: 'flex' }}>
        <ResponsiveDrawer />
        <HomePageBody />
      </Box>
    </>
  );
}
)
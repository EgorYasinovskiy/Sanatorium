import { useContext, useEffect, useState } from 'react'
import ApiContext from '../ApiContext';

import { StaffList } from '../APIServices/StaffServiceDataContract';
import StaffListComp from '../components/StaffListComp/StaffListComp';
let data : StaffList;
const StaffPage =() => {
  var [loading, setLoading] = useState(true);
  var [responseData, setResponseData] = useState(data)
  var apiContext = useContext(ApiContext)
  useEffect(()=>{
    const fetchData = async()=>{
      console.log("loadingdata")
      setLoading(true);
      try{
        const res = await apiContext?.Staff.staffGetAllStaff()
        setResponseData(res!.data);
        console.log(res);
        setLoading(false);
      }catch(error){
        console.log(error)
      }
      setLoading(false);
    }
    fetchData();
  },[setResponseData, setLoading]);
  return (
    <div>
      {
        <>
        {loading ? <div className="center"> <h3>Loading data</h3></div> :
        (responseData?.staff ?  <StaffListComp StaffList={responseData} setStaffList={setResponseData}/> : 
            <div className="center">
                <h3>Не удалось получить данные.</h3>
            </div>
        )
       
      }</>
      }
    </div>
  );
}
export default StaffPage;
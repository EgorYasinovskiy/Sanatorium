import React, { useContext, useEffect, useState } from 'react'
import PatientListComp from '../components/PatientListComp/PatientListComp';
import ApiContext from '../ApiContext';
import { PatientList } from '../APIServices/PatientDataContract';
import { HttpResponse } from '../APIServices/http-client';
import axios from 'axios';
import config from '../ConnectionStrings';

type Props = {}



let data : PatientList;
const PatientsPage =() => {
  var [loading, setLoading] = useState(true);
  var [responseData, setResponseData] = useState(data)
  var apiContext = useContext(ApiContext)
  useEffect(()=>{
    const fetchData = async()=>{
      console.log("loadingdata")
      setLoading(true);
      try{
        const res = await apiContext?.Patient.patientGetAll();
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
        <PatientListComp PatientList={responseData}/>
      }</>
      }
    </div>
  );
  // var apiContext = useContext(ApiContext);
  // apiContext?.Patient.patientGetAll().then((response)=>{data=response});
}
export default PatientsPage;
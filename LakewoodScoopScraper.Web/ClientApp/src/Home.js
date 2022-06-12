import React, {useState, useEffect} from 'react';
import axios from 'axios';

const Home = () => {
    const [items, setItems] = useState([]);
    //const [searchText, setSearchText] = useState('');

   // const onButtonClick = async () => {
   //     const { data } = await axios.get(`/api/lakewoodscoop/scrape`);
    //    setItems(data);
    //}
    useEffect(() => {
        const getItems=async()=>{
        const { data } = await axios.get(`/api/lakewoodscoop/scrape`);
         setItems(data);
        }
        getItems();
        
      }, []);

    return (
        <div className='container mt-5'>
          
            <div className='row mt-3'>
                <div className='col-md-12'>
                {!!items.length && <table className='table table-hover table-striped table-bordered'>
                    <thead>
                        <tr>
                            <th>Image</th>
                            <th>Title</th>
                            <th>Text</th>
                            <th>Comments</th>
                        </tr>
                    </thead>
                    <tbody>
                        {items.map((item, idx) => {
                            return <tr key={idx}>
                                <td><img src={item.image} /></td>
                                <td>
                                    <a href={item.link} target='_blank'>{item.title}</a>
                                </td>
                                <td>
                                    {item.text}
                                </td>
                                <td>
                                    {item.numberOfComments}
                                </td>
                            </tr>
                        })}
                    </tbody>
                    </table>}
                    </div>
            </div>
        </div>
    )
}

export default Home;
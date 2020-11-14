import 'antd/dist/antd.css';
import { Input, Row, Col, Table, Tag, Space } from 'antd';
import swal from 'sweetalert';
import lyricdata from "./data/2020-11-9 23h7m41s.json";
import { useEffect, useState } from 'react';

const { Search } = Input;

function App() {

  const [data, setData] = useState([]);

  useEffect(() => {
    setData(lyricdata);
  }, []);

  const onSearch = value => {

    if (value === "") {
      setData(lyricdata);
      return;
    }

    const dataSearch = lyricdata.filter(item => item.name.toLocaleLowerCase().includes(value.toLocaleLowerCase()) || item.composer.toLocaleLowerCase().includes(value.toLocaleLowerCase()));

    if (dataSearch.length === 0) {
      setData([]);
      swal({
        title: "Thông báo",
        text: "Không tìm thấy bài hát!",
        icon: "error",
        button: "Đồng ý",
      });
    } else {
      setData(dataSearch);
      console.log(data);
      swal({
        title: "Thông báo",
        text: "Thành công!",
        icon: "success",
        button: "Đồng ý",
      });
    }

  }

  const columns = [
    {
      title: 'id',
      dataIndex: 'id',
      key: 'id',
    },
    {
      title: 'Tên bài hát',
      dataIndex: 'name',
      key: 'name',
    },
    {
      title: 'Nhạc sĩ',
      dataIndex: 'composer',
      key: 'composer',
    }
  ];

  return (
    <Row>
      <Col span={16} offset={4} style={{ marginTop: "50px" }}>
        <Search
          placeholder="Nhập tên bài hát..."
          allowClear
          enterButton="Tìm kiếm"
          size="large"
          onSearch={onSearch}
        />
      </Col>
      <Col span={16} offset={4} style={{ marginTop: "50px" }}>
        <Table columns={columns} dataSource={data} />
      </Col>
    </Row>
  );
}

export default App;
import React, { createContext, useState, useContext, useEffect } from 'react';

export const UserContext = createContext();

export const UserProvider = ({ children }) => {
  // Verifica se há um valor no localStorage e usa como valor inicial
  const storedUserRole = localStorage.getItem('userRole');
  const storedUserName = localStorage.getItem('userName');
  const storedUserToken = localStorage.getItem('userToken');

  const [userRole, setUserRole] = useState(storedUserRole || null);
  const [userName, setUserName] = useState(storedUserName || null);
  const [userToken, setUserToken] = useState(storedUserToken || null);

  // Atualiza o localStorage sempre que o userRole mudar
  useEffect(() => {
    if (userRole !== null) {
      localStorage.setItem('userRole', userRole);
      localStorage.setItem('userName', userName);
      localStorage.setItem('userToken', userToken);
    } else {
      localStorage.removeItem('userRole');
      localStorage.removeItem('userName');
      localStorage.removeItem('userToken');
    }
  }, [userRole, userName, userToken]);

  return (
    <UserContext.Provider value={{ userRole, setUserRole, userName, setUserName, userToken, setUserToken }}>
      {children}
    </UserContext.Provider>
  );
};

export const useUser = () => useContext(UserContext);

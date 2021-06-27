import { useCallback, useMemo, useState } from 'react';

type Config = {
  initialPage?: number;
};
export default function (config?: Config) {
  const { initialPage = 1 } = config || {};

  const [currentPage, setCurrentPage] = useState(initialPage);
  const [totalPages, setTotalPages] = useState<number>(1);

  const params = useMemo(
    () => ({
      page: currentPage,
    }),
    [currentPage],
  );

  const nextPage = useCallback(() => {
    if (currentPage < totalPages) {
      setCurrentPage((old) => old + 1);
    }
  }, [currentPage, totalPages]);

  const previousPage = useCallback(() => {
    if (currentPage > 1) {
      setCurrentPage((old) => old - 1);
    }
  }, [currentPage]);

  return {
    params,
    currentPage,
    totalPages,
    setTotalPages,
    setCurrentPage,
    nextPage,
    previousPage,
  };
}

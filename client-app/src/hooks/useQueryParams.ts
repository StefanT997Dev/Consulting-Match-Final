import { useCallback, useMemo } from 'react';
import { useHistory, useLocation } from 'react-router-dom';

const getParamsObj = (urlParams: URLSearchParams) => {
  const res: { [key: string]: string } = {};

  urlParams.forEach((value, key) => (res[key] = value));

  return res;
};

const generateSearch = (urlParams: URLSearchParams) =>
  `?${urlParams.toString()}`;

export default <Params extends { [K in keyof Params]?: string } = {}>() => {
  const { search } = useLocation();
  const history = useHistory();

  const urlSearchParams = useMemo(() => new URLSearchParams(search), [search]);

  const paramsObj = useMemo(() => getParamsObj(urlSearchParams) as Params, [
    urlSearchParams,
  ]);

  const setQueryParam = useCallback(
    (key: keyof Params, value: string, replace = false) => {
      urlSearchParams.set(key as string, value);
      history[replace ? 'replace' : 'push']({
        search: generateSearch(urlSearchParams),
      });
    },
    [history, urlSearchParams],
  );

  const removeQueryParam = useCallback(
    (key: keyof Params, replace = false) => {
      urlSearchParams.delete(key as string);
      history[replace ? 'replace' : 'push']({
        search: generateSearch(urlSearchParams),
      });
    },
    [history, urlSearchParams],
  );

  return { params: paramsObj, setQueryParam, removeQueryParam };
};

(ns bird-watcher)

(def last-week [0 2 5 3 7 8 4])

(defn today [birds]
  (get birds 6)
  )

(defn inc-bird [birds]
  (assoc birds 6 (+ (get birds 6) 1))
  )

(defn day-without-birds? [birds]
  (> (count (filter (fn [x] (= x 0)) birds)) 0)
  )

(defn n-days-count [birds n]
  (reduce + (take n birds))
  )

(defn busy-days [birds]
  (count (filter (fn [x] (>= x 5)) birds))
  )

(defn odd-week? [birds]
  (= birds [1 0 1 0 1 0 1])
  )

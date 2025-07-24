(ns interest-is-interesting)

(defn interest-rate
  [balance]
  (cond (neg? balance) -3.213
        (< balance 1000) 0.5
        (< balance 5000) 1.621
        :else 2.475
    )
  )

(defn one-percent
  [balance]
  (/ balance 100)
  )

(defn annual-balance-update
  [balance]
  (->
    (interest-rate balance)
    (Math/abs)
    (bigdec)
    (* (one-percent balance))
    (+ balance)
    )
  )

(defn amount-to-donate
  [balance tax-free-percentage]
  (cond (neg? balance) 0
        :else (-> 
                (if (pos? balance) 2 1)
                (* (one-percent balance) tax-free-percentage)
                (int)
            )
    )
  )